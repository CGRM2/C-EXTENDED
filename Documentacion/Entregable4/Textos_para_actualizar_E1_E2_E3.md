# Actualizacion documental de C extended

Revision del 15 de octubre de 2026 vinculada al Entregable 4. Este documento contiene textos y tablas para incorporar como actualizacion posterior a los entregables 1, 2 y 3. Conserva el significado de sus fechas y resultados historicos; los archivos originales permanecen intactos.

Los encabezados de destino se tomaron de los documentos reales. La lista completa de cambios y su evidencia esta en Cambios_lexicos_y_ajustes_entregables.md. Las actualizaciones de especificacion no deben confundirse con nuevas funciones del motor: varias capacidades ya existian antes de esta revision.

## Actualizacion del Entregable 1

Documento de destino: Especificacion_lexica_y_diseno_conceptual.docx. Anadir una nota de revision posterior y usar los bloques siguientes en una copia revisada. Mantener la eleccion del subconjunto propio basado en C#, la bitacora y la fecha historica de la entrega original.

### Listado de Palabras Reservadas

Texto de actualizacion: C-extended conserva las trece palabras iniciales y utiliza treinta palabras reservadas. La comparacion es ordinal y sensible a mayusculas; solo el identificador completo se compara con la lista. Las ampliaciones ya estaban presentes en el nucleo suministrado para revision, por lo que se documentan como continuidad y no como treinta nuevas implementaciones.

| Conjunto | Palabras |
| --- | --- |
| Inicial, 13 palabras | namespace, class, enum, func, var, nil, if, else, for, while, return, break, continue |
| Ampliacion ya presente, 17 palabras | int, float, double, char, bool, string, void, static, true, false, switch, case, default, public, private, using, new |

### Matriz de Tokens y Expresiones Regulares

Insertar estas definiciones auxiliares antes de sustituir la matriz. Las expresiones son notacion formal para documentar el lenguaje; el programa reconoce manualmente los caracteres y no ejecuta estas expresiones con Regex de .NET.

| Simbolo | Definicion exacta |
| --- | --- |
|  | Conjunto de unidades UTF-16 (char de .NET) que recibe Analizar(string). El lector de la interfaz valida la codificacion y rechaza NUL antes de cargar el editor; esa validacion de archivo es una etapa diferente. |
| L | Unidad UTF-16 para la que char.IsLetter devuelve true. El guion bajo se define aparte. Se admiten letras como n y a; no se afirma soporte de todos los puntos de codigo Unicode ni de todas las secuencias combinantes. |
| D | Conjunto de los diez digitos ASCII: {0,1,2,3,4,5,6,7,8,9}. Lo reconoce AutomataAFD.EsDigito. |
| G | El caracter guion bajo: _. |
| E | Caracteres que pueden seguir a una barra invertida en un escape: n, t, r, 0, barra invertida, comilla doble y comilla simple. Son siete caracteres; no son siete saltos o valores ya decodificados. |
| C_s |  excepto comilla doble, barra invertida, CR y LF. |
| C_c |  excepto comilla simple, barra invertida, CR y LF. |
| C_l |  excepto CR y LF. |
| A y B | A =  excepto asterisco. B =  excepto asterisco y diagonal /. |
| Notacion |  significa union,  concatenacion y * cerradura de Kleene. Los parentesis agrupan; las comillas dobles tipograficas   delimitan caracteres o cadenas literales. X+ es solo abreviatura de XX*: en la matriz se usa su expansion. |

| Categoria | Expresion formal | Tres lexemas validos |
| --- | --- | --- |
| TK_RESERVADA | namespace  class  enum  func  var  nil  if  else  for  while  return  break  continue  int  float  double  char  bool  string  void  static  true  false  switch  case  default  public  private  using  new | var ; enum ; func |
| TK_IDENTIFICADOR | (L  G)(L  D  G)*, siempre que el lexema completo no pertenezca a las reservadas. | totalVentas ; _i ; nino2 |
| TK_NUM_ENTERO | DD* | 0 ; 15 ; 2026 |
| TK_NUM_DECIMAL | DD*.DD* | 3.1416 ; 0.5 ; 12.0 |
| TK_CADENA | "(C_s  \E)*" | "Activo" ; "A\tB" ; "Hola, \"C\"" |
| TK_CARACTER | '(C_c  \E)' | 'a' ; '9' ; '\n' |
| TK_OP_ARITMETICO | +  -  *  /  %  ++  -- | + ; * ; ++ |
| TK_OP_RELACIONAL | ==  !=  <  >  <=  >= | == ; <= ; != |
| TK_OP_LOGICO | &&  \|\|  ! | && ; \|\| ; ! |
| TK_OP_ASIGNACION | =  +=  -=  *=  /=  %= | = ; += ; %= |
| TK_DELIMITADOR | (  )  {  }  [  ]  ;  ,  .  : | {, ;, : |
| TK_COMENTARIO_LINEA | //C_l* | // uno ; // dos ; // @ |
| TK_COMENTARIO_BLOQUE | /*(A  ***B)****/ | /**/ ; /*nota*/ ; /* * */ |

Los delimitadores de la notacion no forman parte del lexema: por ejemplo, // representa las dos diagonales. En TK_CARACTER, las comillas simples de apertura y cierre si pertenecen al lexema. Los ejemplos con barra invertida muestran el codigo fuente, no una cadena ya desescapada.

La expresion de comentario de bloque obliga a que el primer cierre */ termine el token. A no contiene asterisco y B no contiene asterisco ni diagonal, por lo que el cuerpo no puede absorber un cierre y elegir uno posterior. Los comentarios no son anidados y pueden contener saltos de linea.

Prioridades: los comentarios se prueban antes de la division y los operadores de dos caracteres antes de los de uno. Las cadenas, caracteres y comentarios conservan su lexema original. Un prefijo de una reservada no convierte otro identificador en reservado.

### Convenciones y limites que deben acompanar la matriz

Linea y columna comienzan en 1. CRLF cuenta como un unico salto; LF y CR aislados tambien incrementan la linea y restablecen la columna a 1. Una tabulacion incrementa la columna en una unidad del recorrido, aunque el editor la dibuje con otra anchura. TotalLineas incluye lineas vacias y la linea vacia final cuando existe un salto al final del texto.

Los numeros no incluyen signo, exponente ni prefijos de base. -12 produce el operador - y el entero 12. .5 produce el delimitador . y el entero 5: no es un decimal admitido por esta gramatica. 1. es un error; 1.2 es valido. Una continuacion numerica invalida se consume como una secuencia completa antes de reanudar en el separador.

Un caracter literal contiene exactamente una unidad UTF-16 o un escape permitido. Un simbolo que ocupa dos unidades UTF-16 no se acepta como un unico caracter literal. Las letras de identificadores siguen el predicado indicado para L, no una promesa general de aceptar cualquier caracter Unicode.

### Reglas para la Deteccion de Errores Lexicos

| Regla | Ejemplo de entrada | Secuencia y recuperacion |
| --- | --- | --- |
| Identificador con inicio numerico | 12variable; final | Error por 12variable. Se conserva ; para reconocerlo despues y continua hasta final. |
| Decimal con continuacion invalida | 45.12.3; final o 1.2abc; final | Un error por el lexema completo; se consumen letras, digitos, guion bajo y puntos de la continuacion invalida hasta el separador. |
| Falta digito tras el primer punto | 12.abc; final o 1..2abc; final | Error por 12.abc o 1..2abc completos. No se agrega abc como identificador. |
| Cadena sin cerrar | Comilla doble seguida de contenido y fin de linea o EOF | Se reporta desde la comilla inicial hasta antes del salto; el salto queda para el recorrido principal. En EOF termina el analisis. |
| Escape invalido en cadena | "A\q"; final | Si existe cierre, el error incluye toda la cadena con sus comillas. Un escape invalido no genera otro token independiente. |
| Cantidad invalida en caracter literal | ''; final o 'ab'; final | Error por el literal cerrado completo; debe contener una unidad o un escape valido. |
| Escape invalido en caracter | '\q'; final | Error por el literal completo; continua despues de su cierre. |
| Caracter literal sin cerrar | Comilla simple abierta hasta salto o EOF | Error hasta antes del salto o hasta EOF; puede continuar en la linea siguiente si existe. |
| Comentario de bloque sin cerrar | /* comentario hasta EOF | Consume el resto del archivo y genera un error. Un @ dentro de ese comentario no es otro error. |
| Caracter no permitido | @ var final = 1; o # | Consume la unidad invalida y continua; la posicion indica su inicio. |

Los diagnosticos se refieren al comienzo de la secuencia erronea. Si una cadena o un caracter no tiene cierre, se prioriza el diagnostico de falta de cierre. En caracteres cerrados, el escape invalido se informa antes que la cantidad incorrecta de unidades.

### Estructura Preliminar de la Tabla de Simbolos

Texto de actualizacion: la estructura final conserva los cuatro atributos originales. Simbolo esta definido en TablaDeSimbolos.cs; sus propiedades son publicas para lectura y tienen asignacion privada. La tabla usa Dictionary<string, Simbolo> con StringComparer.Ordinal y una lista para conservar el orden de primera aparicion.

| Atributo | Tipo | Significado |
| --- | --- | --- |
| NombreIdentificador | string | Lexema exacto del identificador. |
| TipoToken | string | TK_IDENTIFICADOR; categoria lexica, no tipo semantico de variable. |
| LineaPrimeraAparicion | int | Primera linea, desde 1. |
| ColumnaInicio | int | Primera columna, desde 1. |

### Mecanismo de Control de Duplicados

AgregarSimbolo registra unicamente identificadores que todavia no estan en el diccionario. Repetir el mismo identificador conserva la primera ubicacion. Nombres que difieren en mayusculas son distintos. ObtenerSimbolos devuelve una lista nueva en orden de registro. Estas garantias ya existian en el motor revisado; aqui se documenta su forma real.

## Actualizacion del Entregable 2

Documento de destino: SEGUNDO ENTREGABLE - ANALIZADOR LEXICO.dotx. Actualizar Seccion 1 - Diagrama del AFD, Seccion 2 - Tabla de Transiciones y Seccion 3 - Arquitectura UML. La nomenclatura siguiente sustituye las etiquetas contradictorias de las versiones previas; los nombres Q son estados conceptuales de los reconocedores, no nuevos campos ni una tabla ejecutada por el codigo.

### Seccion 1 Diagrama del AFD

El dibujo original usa S6 para aceptacion de cadena y S7 para barra, mientras sus tablas llaman S6 a barra y S7 al comentario de linea. Sustituir esas etiquetas por la nomenclatura unica de las tablas siguientes. El reconocimiento real se distribuye en metodos manuales de AnalizadorLexico; AutomataAFD contiene predicados, reservadas y escapes, no el bucle principal del automata.

| Estado o familia | Funcion y aceptacion |
| --- | --- |
| Q0 | Despachador inicial del siguiente lexema. Ignora blancos, selecciona reconocedor y termina en EOF. |
| QI | Identificador/reservada: finaliza al encontrar un caracter que no sea L, D o G. |
| QN, QP, QD | Parte entera; punto que exige un digito; parte decimal. QN y QD pueden aceptar al llegar a un separador o EOF. |
| QNE | Recuperacion numerica. Consume R = L  D  G  {punto}; conserva el separador posterior. El motivo depende de la rama de entrada. |
| QS y QSE | Cadena normal y caracter posterior a barra invertida. Se conserva una marca de escape invalido. |
| QCk y QCEk | Caracter literal y su escape, con k = 0, 1 o mas de 1 unidades. La aceptacion por cierre exige k=1 y escapes validos. |
| QL | Comentario de linea: acepta antes de CR/LF o en EOF. |
| QB y QB* | Comentario de bloque y posible cierre despues de uno o mas asteriscos. |
| QO | Operador/delimitador: prueba primero pares validos, despues simbolos simples. |
| A y ERR | Salidas de aceptacion y diagnostico; el control vuelve a Q0 si queda entrada. No son errores semanticos. |

Instruccion grafica: redibujar un despachador Q0 y subautomatas separados para identificadores, numeros, cadenas, caracteres, comentarios y operadores. Marcar el inicio, las salidas de aceptacion y error y todas las transiciones de las tablas. La revision de esta etapa entrega las tablas y la descripcion exacta para sustituir el dibujo; no se presenta una imagen nueva como si ya hubiera sido incorporada al DOTX historico. La revision grafica del redibujo queda pendiente.

### Seccion 2 Tabla de Transiciones

Convencion de acciones: C significa consumir el caracter; K significa conservarlo para que el siguiente reconocimiento lo procese. EOF es una condicion de fin, no un caracter consumible. Las tablas representan funciones con anticipacion de entrada y sus salidas, de acuerdo con el recorrido manual implementado.

| Estado | Entrada | Siguiente o salida | Accion |
| --- | --- | --- | --- |
| Q0 | Blanco segun char.IsWhiteSpace | Q0 | C; Avanzar actualiza linea/columna. |
| Q0 | L o G | QI | C; guardar indice, linea y columna de inicio. |
| QI | L, D o G | QI | C. |
| QI | Otro o EOF | A | K si hay caracter; clasificar lexema completo con EsReservada; si no, registrar simbolo. |
| Q0 | D | QN | C. |
| QN | D | QN | C. |
| QN | Punto . | QP | C; primer punto, todavia no es decimal valido. |
| QN | L o G | QNE | C mientras la entrada pertenezca a R; motivo: inicio numerico. |
| QN | Separador u EOF | A entero | K si hay caracter. |
| QP | D | QD | C; ya existe al menos un digito fraccionario. |
| QP | No D o EOF | QNE / ERR | Consumir unicamente la continuacion R si existe; motivo: falta digito tras el punto. |
| QD | D | QD | C. |
| QD | Punto, L o G | QNE | C mientras pertenezca a R; motivo: decimal mal formado. |
| QD | Separador u EOF | A decimal | K si hay caracter. |
| QNE | R = L, D, G o punto | QNE | C; incluir toda la secuencia invalida en el error. |
| QNE | Fuera de R o EOF | ERR | K si hay caracter; registrar error desde la ubicacion inicial. |

Cadenas: en las filas siguientes, la marca b comienza en falso. No forma parte del texto; registra si aparecio algun escape invalido y puede representarse mediante dos variantes finitas de QS/QSE.

| Estado | Entrada | Siguiente o salida | Accion |
| --- | --- | --- | --- |
| Q0 | Comilla doble | QS | C; comienza el lexema. |
| QS | C_s | QS | C. |
| QS | Barra invertida | QSE | C. |
| QSE | E | QS | C; conservar b. |
| QSE | Otro excepto CR/LF/EOF | QS | C; establecer b=true. |
| QS | Comilla doble | A o ERR | C; si b=false emitir TK_CADENA; si b=true informar escape invalido. |
| QS o QSE | CR, LF o EOF | ERR | K si es salto; informar cadena sin cerrar. |

Caracteres literales: k se limita conceptualmente a 0, 1 o mas de 1; cada unidad normal o cada par de escape suma una unidad. b senala escape invalido. La implementacion usa un contador y un booleano; las variantes finitas permiten dibujar el reconocedor sin afirmar que existe un parser.

| Estado | Entrada | Siguiente o salida | Accion |
| --- | --- | --- | --- |
| Q0 | Comilla simple | QC0 | C; k=0, b=false. |
| QCk | C_c | QC(k+1) | C; saturar la categoria conceptual de k en mas de 1. |
| QCk | Barra invertida | QCEk | C. |
| QCEk | E | QC(k+1) | C; una unidad por escape. |
| QCEk | Otro excepto CR/LF/EOF | QC(k+1) | C; b=true. |
| QCk | Comilla simple | A o ERR | C; aceptar solo con k=1 y b=false. Si b=true, informar escape invalido; de lo contrario, cantidad incorrecta. |
| QCk o QCEk | CR, LF o EOF | ERR | K si es salto; informar caracter sin cerrar. |

Comentarios: Q0 anticipa el segundo caracter para priorizar // y /* sobre division. Las transiciones QB/QB* que siguen expresan el mismo cierre que LeerComentarioBloque implementa anticipando */.

| Estado | Entrada | Siguiente o salida | Accion |
| --- | --- | --- | --- |
| Q0 | Par // | QL | Consumir las dos diagonales. |
| QL | C_l | QL | C. |
| QL | CR, LF o EOF | A | K si es salto; emitir TK_COMENTARIO_LINEA. |
| Q0 | Par /* | QB | Consumir apertura. |
| QB | No asterisco | QB | C; CR/LF actualizan posicion. |
| QB | Asterisco | QB* | C. |
| QB* | Asterisco | QB* | C; conservar la posibilidad de cierre. |
| QB* | Diagonal / | A | C; primer cierre: emitir TK_COMENTARIO_BLOQUE. |
| QB* | Otro caracter | QB | C; sigue siendo contenido del bloque. |
| QB o QB* | EOF | ERR | Comentario multilinea sin cerrar; el error abarca hasta EOF. |

En la fila QB con no asterisco, EOF se trata por la ultima fila y no como caracter. En QB*, otro caracter excluye asterisco, diagonal y EOF. Los prefijos /* internos son texto y no aumentan una profundidad de anidamiento.

| Familia | Pares reconocidos antes de los simples | Simbolos simples |
| --- | --- | --- |
| Aritmeticos | ++ -- | + - * / % |
| Relacionales | == != <= >= | < > |
| Logicos | && \|\| | ! |
| Asignacion | += -= *= /= %= | = |
| Delimitadores | No hay pares. | ( ) { } [ ] ; , . : |

QO consume dos caracteres solo cuando el par es valido. Si no lo es, consume unicamente el simbolo simple y conserva el siguiente. Una barra aislada o seguida de = se trata como operador una vez descartados comentarios. & y | aislados no son operadores admitidos: generan error de caracter no permitido. Cualquier otra unidad no definida consume una unidad y genera un error antes de volver a Q0.

### Seccion 3 Arquitectura UML

| Clase y archivo | Responsabilidad real | Relaciones y operaciones relevantes |
| --- | --- | --- |
| AnalizadorLexico / Core | Cursor, posiciones, listas, reconocedores y recuperacion manual. | Usa AutomataAFD y TablaDeSimbolos; crea Token y ErrorLexico. Analizar(string), AnalizarArchivo(string), ObtenerTokens(), ObtenerErrores(), ObtenerSimbolos(), TotalLineas. |
| AutomataAFD / Core | Predicados compartidos, conjunto de reservadas y escapes. | EsDigito(char), EsInicioIdentificador(char), EsParteIdentificador(char), EsReservada(string), EsEscapeValido(char). No es la clase que recorre el archivo. |
| Token y ErrorLexico / Core | Modelos de salida con lectura publica y asignacion privada. | Token: Lexema, TipoToken, Linea, Columna. ErrorLexico: CaracterInvalido, Linea, Columna, Descripcion. |
| Simbolo y TablaDeSimbolos / Core/TablaDeSimbolos.cs | Modelo de identificador y registro unico ordenado. | Diccionario ordinal y lista de orden. AgregarSimbolo y ObtenerSimbolos. No duplicar Simbolo en otro archivo. |
| FrmPrincipal / UI | Carga, editor, numeracion, eventos, estado, tablas y estadisticas. | Clase parcial con FrmPrincipal.Designer.cs y FrmPrincipal.resx; usa AnalizadorLexico, ResultadoAnalisis y Exportador. Sustituye el nombre conceptual FormPrincipal. |
| ResultadoAnalisis / UI | Instantanea del analisis para presentacion y exportacion. | Tokens, Errores, Simbolos, TotalLineas, TiempoMs, NombreFuente, TextoAnalizado y FechaHora. Copia las listas de entrada; sus propiedades List siguen siendo mutables. |
| Exportador / UI | Escritura del informe TXT y escapes reversibles. | ExportarTxt y EscaparCadena/DesescaparCadena. Recibe los objetos del resultado; no reconstruye datos desde las celdas. |
| Program / raiz | Punto de entrada de Windows Forms. | Main con STAThread y Application.Run(new FrmPrincipal()). |

Relaciones para el UML: Program inicia FrmPrincipal; FrmPrincipal usa AnalizadorLexico y crea ResultadoAnalisis; AnalizadorLexico usa AutomataAFD y contiene una TablaDeSimbolos; las listas del nucleo contienen Token y ErrorLexico; TablaDeSimbolos contiene Simbolo; ResultadoAnalisis mantiene listas copiadas de esos modelos; Exportador depende de ResultadoAnalisis y de los modelos para escribir el informe.

Controles reales de FrmPrincipal: rtbEditor, pnlNumeros, dgvTokens, dgvErrores, dgvSimbolos, txtEstadisticas y etiquetas de resumen/estado. Eventos: btnCargar_Click, btnAnalizar_Click, btnExportar_Click y btnLimpiar_Click. El estado de resultados se invalida al editar o si ocurre una excepcion durante el analisis.

La lectura estricta pertenece a FrmPrincipal.IntentarLeerArchivo y a su auxiliar privado IntentarDecodificarArchivo. El metodo del nucleo AnalizarArchivo todavia usa File.ReadAllText; no se le atribuye la misma politica estricta de la interfaz. Los cambios de formato del informe y de numeracion no modifican la gramatica lexica.

### Seccion 4 Repositorio y Mockup

Conservar el mockup y las capturas historicas como diseno del Entregable 2. En la actualizacion del Entregable 4 anadir las capturas reales del manual y una nota que explique su evolucion. La publicacion y el tag/release del E4 siguen pendientes de verificar; no sustituir el enlace historico por una publicacion que no se haya comprobado.

## Actualizacion del Entregable 3

Documento de destino: Entregable3_final.pdf. Conservar intacto el informe original y sus 28 verificaciones. Incorporar los textos siguientes como revision posterior vinculada al Entregable 4, o en una copia revisada cuya fecha de actualizacion sea explicita.

### Alcance de esta etapa y Arquitectura

Actualizacion posterior: el nucleo del Entregable 3 se integro con FrmPrincipal, una interfaz Windows Forms con editor, numeracion, tablas independientes, estadisticas y exportacion TXT. Se mantienen C-extended y el reconocimiento manual. Las clases de presentacion ResultadoAnalisis y Exportador pertenecen a UI y no convierten el motor en un analizador sintactico o semantico.

### Decisiones de implementacion y Dificultades y soluciones

Se corrigio el consumo parcial de algunas secuencias numericas invalidas. La version recibida para revision podia reportar 12. como error y registrar abc como identificador al leer 12.abc. La revision consume 12.abc y 1..2abc completos como un unico error numerico y conserva el separador y los tokens validos posteriores. Este cambio completa la intencion de recuperacion descrita en el informe historico, sin afirmar que todos esos casos ya habian sido probados entonces.

Se introdujo EsDigito como predicado ASCII compartido y se sustituyeron las llamadas numericas a char.IsDigit, que aceptaban tambien otras cifras Unicode. La definicion formal de D y la continuacion de identificadores ahora coinciden con los digitos 0-9. Se conservan las letras admitidas por char.IsLetter y el guion bajo.

La interfaz valida todo el texto decodificado para rechazar NUL antes de asignarlo al editor. Se elimino la numeracion final adicional; se agrego InvalidarResultados al manejo de excepciones de analisis; ResultadoAnalisis copia las listas recibidas. Se alineo App.config con .NET Framework 4.8. Estos cambios de entrada, presentacion y estado no deben presentarse como nuevas categorias lexicas.

### Pruebas y resultados

Resultado historico que se conserva: 28 verificaciones aprobadas y 0 fallidas en el Entregable 3. La suite actual del proyecto contiene 76 comprobaciones y produjo 76 aprobadas y 0 fallidas. Los cinco conteos historicos de tokens/simbolos/errores se mantienen; la revision no reemplaza las 28 verificaciones antiguas por 76 como si ambos resultados fueran de la misma fecha.

| Archivo del proyecto actual | Tokens | Simbolos | Errores | Estado |
| --- | --- | --- | --- | --- |
| prueba1_sencillo.txt | 25 | 3 | 0 | Aprobado |
| prueba2_medio.txt | 62 | 9 | 0 | Aprobado |
| prueba3_errores.txt | 20 | 4 | 4 | Aprobado |
| prueba4_recuperacion.txt | 21 | 4 | 2 | Aprobado |
| prueba5_categorias.txt | 59 | 7 | 0 | Aprobado |
| prueba6_interfaz_exportacion.txt original de AAA2/Pruebas | 67 | 11 | 1 | Aprobado; 30 lineas |
| Prueba 6 nueva de la carpeta documental | 98 | 15 | 1 | Aprobado; 32 lineas |

Las dos pruebas 6 tienen contenido distinto y se conservan separadas. La nueva esta en Entradas/Prueba6_nueva y coincide con las capturas del manual y la exportacion real del usuario. Sus conteos distintos no son una regresion. En prueba3 tambien existen diferencias de espacios o salto final entre copias: la del proyecto actual tiene 20 lineas y la copia documental historica 19, conservando 20 tokens, 4 simbolos y 4 errores.

| Conjunto de evidencia actual | Resultado | Que verifica |
| --- | --- | --- |
| Suite del proyecto | 76/76 | Continuidad de los seis archivos del proyecto, carga, exportacion, construccion del formulario y sus controles. |
| Carga estricta | 25/25 | Codificaciones validas e invalidas, vacios, NUL en distintas posiciones y rechazo de UTF-32. |
| Numeros y recuperacion | 28/28 | Lexema invalido completo, ubicaciones, separador posterior, enteros/decimales y continuidad historica. |
| Digitos e identificadores | 12/12 | Predicado ASCII en 65536 valores char y ejemplos de reconocimiento. |
| Exportacion real de la nueva prueba 6 | 114 registros coincidentes | 98 tokens, 1 error y 15 simbolos comparados campo por campo y en orden. |

Los conjuntos de comprobaciones tienen coberturas parcialmente relacionadas y no se suman como si fueran archivos o pruebas independientes. El tiempo del analisis depende de la ejecucion y se registra en milisegundos enteros; un valor 0 ms no implica ausencia de analisis.

### Compilacion y ejecucion reproducible

El proyecto principal actual y PruebasConsola apuntan ambos a .NET Framework 4.8. Se compilo una copia completa de los archivos guardados en Debug y Release mediante MSBuild de Visual Studio; el resultado fue satisfactorio. App.config y los exe.config generados indican CLR v4.0 y sku .NETFramework,Version=v4.8.

El SDK .NET 10 y el comando dotnet run documentados en el informe del Entregable 3 describen el ejecutor historico. La suite actual es un proyecto de .NET Framework 4.8 con referencia a la aplicacion. Para la version actual, compilar PruebasConsola.csproj con las herramientas de .NET Framework de Visual Studio y ejecutar su PruebasConsola.exe indicando la carpeta Pruebas como argumento. Conservar la explicacion historica en el original; no presentarla como requisito de instalacion del ejecutable final.

Ejemplo actual desde la raiz del proyecto, despues de compilar en Debug: PruebasConsola\bin\Debug\PruebasConsola.exe .\Pruebas. La evidencia se escribe en la carpeta de pruebas indicada; conservar por separado cualquier evidencia historica antes de volver a ejecutarla.

### Trazabilidad y alcance pendiente

Se conservaron los archivos originales y las evidencias historicas. El manual de E4 y la matriz de pruebas documentan la version revisada y distinguen comprobaciones automaticas de confirmaciones manuales del grupo. La ejecucion en otro equipo y la publicacion de la version/tag del Entregable 4 siguen pendientes de comprobacion. El video del Entregable 4 se aplazo por decision del grupo; esa decision no modifica los requisitos de la guia ni el video historico del Entregable 3.

El flujo excepcional que invalida resultados al fallar un analisis esta implementado y compila, pero no se provoco una excepcion real del motor durante la revision. Se conserva ese limite en el registro; no se atribuye una prueba forzada que no se ejecuto.

### Reconocimiento de apoyo de IA

Se empleo Antigravity como apoyo para la implementacion e integracion de Windows Forms, y Codex para revisar el codigo y los documentos, proponer correcciones, ejecutar comprobaciones y preparar documentacion. El grupo aplico los cambios y realizo las pruebas manuales descritas. Las capturas proceden de la aplicacion del grupo en ejecucion. Este reconocimiento atiende la norma de la guia sobre citar explicitamente el apoyo de herramientas de IA.
