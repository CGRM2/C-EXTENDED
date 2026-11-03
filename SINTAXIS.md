# Análisis léxico y sintáctico de C-Extended

Abre C-Extended.slnx y ejecuta el proyecto. El botón Analizar y el análisis al editar ejecutan las dos etapas. La pestaña Errores sintácticos muestra ubicación y descripción; su panel inferior explica la gramática admitida.

Si hay errores léxicos, el análisis sintáctico queda pendiente. Corrige primero esos errores: no se interpretan tokens incompletos como un programa válido.

El lenguaje sigue los ejemplos del curso: namespace, class, enum, func, declaraciones con var o tipos, funciones con parámetros, bloques, if/else, while, for, switch/case/default, return, break y continue. Admite asignaciones, llamadas, acceso a miembros y arreglos, operadores con precedencia e incrementos. Las sentencias dentro de clases se permiten para conservar los ejemplos originales del curso.

La tabla de tokens conserva las categorías léxicas y añade el rol de los identificadores declarados. La tabla de símbolos añade las declaraciones encontradas por nombre. Esta información no resuelve ámbitos ni garantiza que una declaración sea correcta si existen errores sintácticos. Las estadísticas y el informe TXT distinguen ambas etapas y sus tiempos.

El diccionario conserva el CRUD de palabras. Agregar una palabra reservada clasifica el token, pero no inventa una regla de sintaxis: una palabra reservada nueva sin regla produce un diagnóstico si se usa como instrucción. Las reglas actuales están implementadas en Core/AnalizadorSintactico.cs.

Este es un analizador de la gramática simplificada de C-Extended, no un compilador completo de C#. No comprueba tipos, nombres sin declarar, duplicados ni compatibilidad de valores. No admite sintaxis ajena a los ejemplos como herencia, genéricos, interpolación de cadenas o try/catch.

## Ejemplos para cargar desde el programa

- PruebasSintaxis/codigo_valido.txt: ejemplo sin errores.
- PruebasSintaxis/errores_sintacticos.txt: falta de punto y coma, números sin operador, operando ausente y paréntesis faltante.
- PruebasSintaxis/errores_lexicos.txt: símbolo inválido y análisis sintáctico pendiente.

## Pruebas automatizadas

Compila PruebasSintaxis/PruebasSintaxis.csproj con MSBuild de Visual Studio y ejecuta su bin/Debug/PruebasSintaxis.exe. Se prueban entradas válidas, inválidas, recuperación, posiciones, límites de anidamiento, exportación y actualización del formulario. La prueba abre un formulario brevemente y guarda sintaxis.png e informe_prueba.txt junto al ejecutable.

## Archivos de la ampliación

- Core/AnalizadorSintactico.cs: gramática, errores, declaraciones y recuperación.
- UI/FrmPrincipal.Sintaxis.cs: pestaña nueva, columnas y explicación del diccionario.
- UI/FrmPrincipal.cs: ejecución, limpieza, resumen y estadísticas de ambas etapas.
- UI/ResultadoAnalisis.cs: resultados separados del mismo texto analizado.
- UI/Exportador.cs: informe TXT con ambas etapas.
- C-Extended.csproj: inclusión de los archivos nuevos.
- PruebasSintaxis/: proyecto de pruebas y ejemplos para cargar.

Validación final: compilación Debug correcta, 92 pruebas sintácticas/de integración, 45 comprobaciones léxicas y 11 de actualización/CRUD aprobadas. Los ejemplos originales válidos 1, 2 y 5 también se aceptan sintácticamente. Se revisaron visualmente las pestañas afectadas.
