using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using C_Extended.Core;
using C_Extended.UI;

class Program
{
    static int aprobadas;
    static void Verificar(string nombre, bool correcto)
    {
        if (!correcto) throw new Exception("FALLÓ: " + nombre);
        aprobadas++;
        Console.WriteLine("APROBADA: " + nombre);
    }
    static ResultadoAnalisis Analizar(string texto)
    {
        var lexico = new AnalizadorLexico();
        lexico.Analizar(texto);
        return new ResultadoAnalisis(lexico.ObtenerTokens(), lexico.ObtenerErrores(),
            lexico.ObtenerSimbolos(), lexico.TotalLineas, 0, "prueba", texto);
    }
    [STAThread]
    static int Main(string[] args)
    {
        try
        {
            string salida = args.Length > 0 ? Path.GetFullPath(args[0]) : AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory(salida);
            string[] validos = {
                "", "// comentario", "var x = 1;", "int x;", "int x = 1, y = 2;",
                "string saludo = \"hola\";", "char letra = 'a';", "bool listo = true;",
                "x = 2 + 3 * 4;", "x += 2;", "x++; --x;", "obj.x = 1; a[0] = 2;",
                "imprimir(x, 2);", "var x = funcion(2);", "var a = new int[4];", "var x = new Clase();",
                "if (x > 0) x--; else x++;", "if (true) { if (false) x++; else x--; }",
                "while (x < 5) { x++; continue; }", "for (var i = 0; i < 5; i++) { if (i == 2) break; }",
                "for (;;) { break; }", "switch (x) { case 1: x++; break; default: x = 0; break; }",
                "enum Estado { Activo, Inactivo }", "enum Estado { A = 1, B = 2, }",
                "namespace Demo { class C { func suma(int a, int b) { return a + b; } } }",
                "public static int suma(int a) { return a; }", "void ejecutar() { return; }",
                "using Sistema.Texto;", "MiClase objeto;", "int[] datos;", "var x = (a + b) * -2;",
                "namespace A.B { class C { var n = 0; if (n == 0) { n += 1; } } }"
            };
            for (int i = 0; i < validos.Length; i++)
            {
                var r = Analizar(validos[i]);
                Verificar("Válido " + i + " " + validos[i], r.Errores.Count == 0 && r.SintaxisEvaluada && r.ErroresSintacticos.Count == 0);
            }
            string[] invalidos = {
                "var x = 1", "var x = ;", "var = 1;", "int int = 2;", "x = 50 10;", "x = 1 + ;",
                "if true { x++; }", "if () x++;", "if (true)", "if (true) { x++;", "}", "x = (1 + 2;",
                "x = a[1;", "else x++;", "for (var i = 0 i < 5; i++) { }", "for (;;) ",
                "while (x > 0 { x--; }", "switch (x) { case 1 x++; }", "switch (x) { default: ; default: ; }",
                "case 1: x++;", "func () {}", "func f(int) {}", "func f(int x, ) {}", "func f() return;",
                "class { }", "namespace { }", "enum E { A B }", "void x;", "x;", "break;", "continue;",
                "1 = 2;", "1++;", "++1;", "f() = 2;", "x = ; var y = 2;", "f(1,);", "obj. = 2;",
                "x = new ;", "if (true) else x++;", "(x);", "x + f();", "f() + 1;", "void f(void x) {}"
            };
            for (int i = 0; i < invalidos.Length; i++)
            {
                var r = Analizar(invalidos[i]);
                Verificar("Inválido " + i + " " + invalidos[i], r.Errores.Count == 0 && r.SintaxisEvaluada && r.ErroresSintacticos.Count > 0);
            }
            var pendiente = Analizar("var x = @;");
            Verificar("No afirmar sintaxis correcta con errores léxicos", !pendiente.SintaxisEvaluada && pendiente.ErroresSintacticos.Count == 0);
            var ubicacion = Analizar("var x = 1;\r\nvar y = ;");
            Verificar("Línea y columna CRLF", ubicacion.ErroresSintacticos[0].Linea == 2 && ubicacion.ErroresSintacticos[0].Columna == 9);
            Verificar("Recuperación conserva siguiente declaración", Analizar("var x = ; var y = 2;").Declaraciones.Any(d => d.Nombre == "y"));
            var eof = Analizar("var x = 1");
            Verificar("Ubicación al final de archivo", eof.ErroresSintacticos.Any(e => e.Linea == 1 && e.Columna == 10));
            Verificar("Límite de anidamiento", Analizar(new string('{', 200)).ErroresSintacticos.Count > 0);
            Verificar("Límite de expresiones", Analizar("var x = " + new string('(', 200) + "1;").ErroresSintacticos.Count > 0);
            var motor = new AnalizadorSintactico();
            motor.Analizar(new System.Collections.Generic.List<Token> { new Token("repetir", "TK_RESERVADA", 1, 1) }, "repetir");
            Verificar("Reservada personalizada requiere regla", motor.Errores.Any(e => e.Descripcion.Contains("regla sintáctica")));
            motor.Analizar(new System.Collections.Generic.List<Token>(), "");
            Verificar("Reutilización reinicia resultados", motor.Errores.Count == 0 && motor.Declaraciones.Count == 0);
            string destino = Path.Combine(salida, "informe_prueba.txt");
            Exportador.ExportarTxt(destino, ubicacion);
            string informe = File.ReadAllText(destino);
            Verificar("Exportación separa ambas etapas", informe.Contains("--- ERRORES LÉXICOS ---") && informe.Contains("--- ERRORES SINTÁCTICOS ---") && informe.Contains("Se esperaba una expresión"));
            Exportador.ExportarTxt(destino, pendiente);
            Verificar("Exportación indica sintaxis pendiente", File.ReadAllText(destino).Contains("Análisis sintáctico pendiente"));
            Application.EnableVisualStyles();
            using (var f = new FrmPrincipal())
            {
                f.Show();
                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var editor = (RichTextBox)typeof(FrmPrincipal).GetField("rtbEditor", flags).GetValue(f);
                var analizar = typeof(FrmPrincipal).GetMethod("btnAnalizar_Click", flags);
                editor.Text = "var x = ;";
                analizar.Invoke(f, new object[] { null, EventArgs.Empty });
                var tabla = (DataGridView)typeof(FrmPrincipal).GetField("dgvSintacticos", flags).GetValue(f);
                Verificar("Pestaña muestra errores sintácticos", tabla.Rows.Count > 0);
                editor.Text = "int x = 1;";
                analizar.Invoke(f, new object[] { null, EventArgs.Empty });
                Verificar("Reanálisis limpia errores sintácticos", tabla.Rows.Count == 0);
                var simbolos = (DataGridView)typeof(FrmPrincipal).GetField("dgvSimbolos", flags).GetValue(f);
                Verificar("Tabla de símbolos muestra declaración", Convert.ToString(simbolos.Rows[0].Cells[5].Value).Contains("variable (int)"));
                var tabs = (TabControl)typeof(FrmPrincipal).GetField("tabResultados", flags).GetValue(f);
                Verificar("Apartados separados", tabs.TabPages.Cast<TabPage>().Any(t => t.Text == "Errores sintácticos") && tabs.TabPages.Cast<TabPage>().Any(t => t.Text == "Diccionario"));
                tabs.SelectedTab = tabs.TabPages.Cast<TabPage>().First(t => t.Text == "Errores sintácticos");
                editor.Text = "var x = ;";
                analizar.Invoke(f, new object[] { null, EventArgs.Empty });
                Application.DoEvents();
                using (var imagen = new Bitmap(f.Width, f.Height))
                {
                    f.DrawToBitmap(imagen, new Rectangle(0, 0, f.Width, f.Height));
                    imagen.Save(Path.Combine(salida, "sintaxis.png"));
                }
                editor.Text = "var x = @;";
                analizar.Invoke(f, new object[] { null, EventArgs.Empty });
                var estado = (Label)typeof(FrmPrincipal).GetField("lblEstadoSintactico", flags).GetValue(f);
                Verificar("Interfaz indica pendiente por error léxico", estado.Text.Contains("PENDIENTE") && tabla.Rows.Count == 0);
                editor.Clear();
                Verificar("Limpiar editor invalida ambas etapas", tabla.Rows.Count == 0 && estado.Text.Contains("Pendiente"));
                f.Close();
            }
            Console.WriteLine("TOTAL: " + aprobadas + " pruebas aprobadas.");
            return 0;
        }
        catch (Exception ex) { Console.WriteLine(ex); return 1; }
    }
}
