# Analisis lexico y sintactico de C-Extended

Abre C-Extended.csproj y ejecuta el proyecto. El boton Analizar y el analisis al editar ejecutan las dos etapas. La pestana Errores sintacticos muestra ubicacion y descripcion; su boton Ayuda permite consultar la gramatica admitida.

Si hay errores lexicos, el analisis sintactico queda pendiente. Corrige primero esos errores: no se interpretan tokens incompletos como un programa valido.

El lenguaje sigue los ejemplos del curso: namespace, class, enum, func, declaraciones con var o tipos, funciones con parametros, bloques, if/else, while, for, switch/case/default, return, break y continue. Admite asignaciones, llamadas, acceso a miembros y arreglos, operadores con precedencia e incrementos. Las sentencias dentro de clases se permiten para conservar los ejemplos originales del curso.

La tabla de tokens conserva las categorias lexicas y anade el rol de los identificadores declarados. La tabla de simbolos anade las declaraciones encontradas por nombre. Esta informacion no resuelve ambitos ni garantiza que una declaracion sea correcta si existen errores sintacticos. Las estadisticas y el informe TXT distinguen ambas etapas y sus tiempos.

El diccionario conserva el CRUD de palabras. Agregar una palabra reservada clasifica el token, pero no inventa una regla de sintaxis: una palabra reservada nueva sin regla produce un diagnostico si se usa como instruccion. Las reglas actuales estan implementadas en Core/AnalizadorSintactico.cs.

Este es un analizador de la gramatica simplificada de C-Extended, no un compilador completo de C#. No comprueba tipos, nombres sin declarar, duplicados ni compatibilidad de valores. No admite sintaxis ajena a los ejemplos como herencia, genericos, interpolacion de cadenas o try/catch.

## Ejemplos para cargar desde el programa

- PruebasSintaxis/codigo_valido.txt: ejemplo sin errores.
- PruebasSintaxis/errores_sintacticos.txt: falta de punto y coma, numeros sin operador, operando ausente y parentesis faltante.
- PruebasSintaxis/errores_lexicos.txt: simbolo invalido y analisis sintactico pendiente.

## Pruebas automatizadas

Compila PruebasSintaxis/PruebasSintaxis.csproj con MSBuild de Visual Studio y ejecuta su bin/Debug/PruebasSintaxis.exe. Se prueban entradas validas, invalidas, recuperacion, posiciones, limites de anidamiento, exportacion y actualizacion del formulario. La prueba abre un formulario brevemente y guarda sintaxis.png e informe_prueba.txt junto al ejecutable.

## Archivos de la ampliacion

- Core/AnalizadorSintactico.cs: gramatica, errores, declaraciones y recuperacion.
- UI/FrmPrincipal.Sintaxis.cs: pestana nueva, columnas y explicacion del diccionario.
- UI/FrmPrincipal.cs: ejecucion, limpieza, resumen y estadisticas de ambas etapas.
- UI/ResultadoAnalisis.cs: resultados separados del mismo texto analizado.
- UI/Exportador.cs: informe TXT con ambas etapas.
- C-Extended.csproj: inclusion de los archivos nuevos.
- PruebasSintaxis/: proyecto de pruebas y ejemplos para cargar.

Validacion de esta revision: compilacion Release correcta; 125 comprobaciones de sintaxis e integracion y 76 comprobaciones de regresion lexica aprobadas. La suite incluye los ejemplos originales validos 1, 2 y 5. Se inspecciono una captura de la pestana de errores sintacticos.

## Revision de calidad

La navegacion por doble clic funciona en errores lexicos, sintacticos, tokens y simbolos. F5 analiza, Ctrl+O carga y Ctrl+E exporta. El informe no puede reemplazar el archivo fuente cargado.

Se reconocen arreglos de tipos propios en declaraciones y cabeceras de for. Cada funcion mantiene un contexto de ciclos y switch independiente, return requiere una funcion y se diagnostican modificadores duplicados o incompatibles. Se rechazan arreglos de void y construcciones new void/new var. Estas comprobaciones no constituyen un analisis semantico de tipos.

El diccionario almacena en cache las clasificaciones para evitar copiar todas las entradas por cada identificador; los cambios del CRUD invalidan esa cache.
