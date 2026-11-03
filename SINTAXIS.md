# Análisis léxico y sintáctico de C-Extended

Abre C-Extended.csproj y ejecuta el proyecto. El botón Analizar y el análisis al editar ejecutan las dos etapas. La pestaña Errores sintácticos muestra ubicación y descripción; su botón Ayuda permite consultar la gramática admitida.

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

Validación de esta revisión: compilación Release correcta; 125 comprobaciones de sintaxis e integración y 76 comprobaciones de regresión léxica aprobadas. La suite incluye los ejemplos originales válidos 1, 2 y 5. Se inspeccionó una captura de la pestaña de errores sintácticos.

## Revisión de calidad

La navegación por doble clic funciona en errores léxicos, sintácticos, tokens y símbolos. F5 analiza, Ctrl+O carga y Ctrl+E exporta. El informe no puede reemplazar el archivo fuente cargado.

Se reconocen arreglos de tipos propios en declaraciones y cabeceras de for. Cada función mantiene un contexto de ciclos y switch independiente, return requiere una función y se diagnostican modificadores duplicados o incompatibles. Se rechazan arreglos de void y construcciones new void/new var. Estas comprobaciones no constituyen un análisis semántico de tipos.

El diccionario almacena en caché las clasificaciones para evitar copiar todas las entradas por cada identificador; los cambios del CRUD invalidan esa caché.
