using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using C_Extended.Core;
using C_Extended.UI;
class Caso { public string Id, Nombre, Entrada, Esperado; public int Lexicos; public bool SintaxisValida; public string Categoria, Lexema; }
class ProgramaFinal {
 [STAThread] static int Main(string[] args) {
 string salida=Path.GetFullPath(args[0]); Directory.CreateDirectory(salida);
 var casos=new List<Caso>();
 Action<string,string,string,int,bool,string,string> add=(id,n,e,l,s,c,x)=>casos.Add(new Caso{Id=id,Nombre=n,Entrada=e,Lexicos=l,SintaxisValida=s,Categoria=c,Lexema=x,Esperado=l>0?l+" error(es) lexico(s); sintaxis pendiente":(s?"0 errores lexicos y sintacticos":"0 errores lexicos; al menos 1 sintactico")});
 add("P01","Declaracion entera","int numero = 10;",0,true,"TK_NUM_ENTERO","10");
 add("P02","Decimal de muchas cifras","double pi = 3.141592653589793238462643383279;",0,true,"TK_NUM_DECIMAL","3.141592653589793238462643383279");
 string largo="identificador_"+new string('a',1024);
 add("P03","Identificador largo","var "+largo+" = 1;",0,true,"TK_IDENTIFICADOR",largo);
 add("P04","Identificador Unicode","var a\u00f1o = 2026;",0,true,"TK_IDENTIFICADOR","a\u00f1o");
 add("P05","Cadena con escapes","string texto = \"Hola\\n\\\"CUNOR\\\"\";",0,true,"TK_CADENA","\"Hola\\n\\\"CUNOR\\\"\"");
 add("P06","Caracter con escape","char salto = '\\n';",0,true,"TK_CARACTER","'\\n'");
 add("P07","Operadores y control","var x = 1; if (x >= 1 && x != 2 || !false) { x += 2; x++; }",0,true,"TK_OP_LOGICO","&&");
 add("P08","Comentarios y delimitadores","// inicio\r\n/* bloque */ int[] datos;",0,true,"TK_COMENTARIO_BLOQUE","/* bloque */");
 add("P09","Funciones y ciclos","func sumar(int a, int b) { return a + b; } for (var i=0; i<3; i++) { sumar(i, 1); }",0,true,"TK_RESERVADA","return");
 add("P10","Entrada vacia","",0,true,null,null);
 add("P11","Errores combinados y recuperacion","var x = @; var y = 12abc; var z = 1..2; var ok = 3;",3,false,"TK_IDENTIFICADOR","ok");
 add("P12","Cadena sin cerrar recupera linea","string x = \"sin cierre\nvar ok = 1;",1,false,"TK_IDENTIFICADOR","ok");
 add("P13","Comentario sin cerrar","int x = 1; /* sin cierre",1,false,null,null);
 add("P14","Comentarios anidados no admitidos","/* exterior /* interior */ resto */",1,false,"TK_IDENTIFICADOR","resto");
 add("P15","Decimales incompletos","var a = .5; var b = 1.;",2,false,null,null);
 add("P16","Caracter de longitud invalida","char a = ''; char b = 'ab';",2,false,null,null);
 add("P17","Escape invalido","string x = \"\\q\";",1,false,null,null);
 add("P18","Punto y coma ausente","int x = 10",0,false,null,null);
 add("P19","Operando ausente","var x = 5 + ;",0,false,null,null);
 add("P20","Control fuera de contexto","return 1; break; continue;",0,false,null,null);
 add("P21","Arreglos de tipo propio","Persona[][] datos;",0,true,"TK_IDENTIFICADOR","Persona");
 add("P22","Contexto de funcion independiente","while (true) { func f() { break; } }",0,false,null,null);
 var resultados=new List<object>(); int fallidas=0;
 foreach(var c in casos) {
 var a=new AnalizadorLexico(); a.Analizar(c.Entrada);
 var r=new ResultadoAnalisis(a.ObtenerTokens(),a.ObtenerErrores(),a.ObtenerSimbolos(),a.TotalLineas,0,c.Id,c.Entrada);
 bool ok=r.Errores.Count==c.Lexicos && (c.Lexicos>0?!r.SintaxisEvaluada:(r.SintaxisEvaluada && ((r.ErroresSintacticos.Count==0)==c.SintaxisValida)));
 if(c.Categoria!=null) ok &= r.Tokens.Any(t=>t.TipoToken==c.Categoria && t.Lexema==c.Lexema);
 if(c.Id=="P08") ok &= r.Tokens.Any(t=>t.Lexema=="int" && t.Linea==2 && t.Columna==14);
 string obtenido=r.Errores.Count+" lexicos; "+(r.SintaxisEvaluada?r.ErroresSintacticos.Count+" sintacticos":"sintaxis pendiente")+"; "+r.Tokens.Count+" tokens; "+r.Simbolos.Count+" simbolos";
 string esperado=c.Esperado+(c.Categoria!=null?". Incluye "+c.Categoria+" con lexema "+(c.Lexema.Length>70?"identificador completo de "+c.Lexema.Length+" caracteres":c.Lexema):"")+(c.Id=="P08"?". int en 2:14":"");
 Directory.CreateDirectory(Path.Combine(salida,"Entradas")); Directory.CreateDirectory(Path.Combine(salida,"Informes"));
 File.WriteAllText(Path.Combine(salida,"Entradas",c.Id+".txt"),c.Entrada,new UTF8Encoding(false));
 Exportador.ExportarTxt(Path.Combine(salida,"Informes",c.Id+".txt"),r);
 resultados.Add(new { id=c.Id,nombre=c.Nombre,entrada=c.Entrada,esperado=esperado,obtenido=obtenido,resultado=ok?"APROBADO":"FALLIDO",tokens=r.Tokens,erroresLexicos=r.Errores,erroresSintacticos=r.ErroresSintacticos });
 Console.WriteLine(c.Id+" "+(ok?"APROBADO":"FALLIDO")+" "+obtenido); if(!ok)fallidas++;
 }
 File.WriteAllText(Path.Combine(salida,"matriz_resultados.json"),new JavaScriptSerializer{MaxJsonLength=10000000}.Serialize(resultados),new UTF8Encoding(false));
 Application.EnableVisualStyles();
 using(var f=new FrmPrincipal()) { f.Show(); var flags=BindingFlags.NonPublic|BindingFlags.Instance; var t=typeof(FrmPrincipal); var editor=(RichTextBox)t.GetField("rtbEditor",flags).GetValue(f); var tabs=(TabControl)t.GetField("tabResultados",flags).GetValue(f);
 foreach(var escenario in new[]{new[]{"valido","int numero = 10;\nif (numero > 0) { numero--; }"},new[]{"sintactico","int numero = 10\nvar total = 5 + ;"},new[]{"lexico","var numero = @;"}}) {
 editor.Text=escenario[1]; t.GetMethod("btnAnalizar_Click",flags).Invoke(f,new object[]{null,EventArgs.Empty});
 foreach(TabPage tab in tabs.TabPages) { if(tab.Text=="Diccionario" && escenario[0]!="valido")continue; tabs.SelectedTab=tab; Application.DoEvents(); using(var b=new Bitmap(f.Width,f.Height)) {f.DrawToBitmap(b,new Rectangle(0,0,f.Width,f.Height)); b.Save(Path.Combine(salida,escenario[0]+"_"+tab.Name+".png"));} }
 } f.Close(); }
 Console.WriteLine("TOTAL: "+casos.Count+" casos; "+fallidas+" fallidos."); return fallidas==0?0:1;
 }
}
