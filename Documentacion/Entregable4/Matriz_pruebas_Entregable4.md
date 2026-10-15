# Matriz de pruebas del Entregable 4

Proyecto: C-extended, analizador léxico en C# Windows Forms.

Fecha de consolidación: 15 de octubre de 2026.

El motor, la integración y los flujos revisados produjeron los resultados esperados. Esta matriz reúne las comprobaciones automáticas, las confirmaciones manuales del usuario y la exportación generada desde su aplicación. La ejecución en otro equipo sigue pendiente; no se presenta como aprobada.

## Alcance de la evidencia

- **Automática sobre el proyecto:** se compiló una copia completa de los archivos guardados del proyecto de AAA2, incluidos el diseñador y los recursos. La comparación posterior de 19 archivos con la copia verificada no encontró diferencias.
- **Manual confirmada por el usuario:** el usuario realizó las acciones descritas y confirmó su resultado en este chat. Una confirmación no se presenta como una captura inexistente.
- **Archivo generado por la aplicación del usuario:** se recibió y se leyó de nuevo el TXT exportado, comparando sus registros con los objetos esperados.
- La captura de rechazo de UTF-8 es la imagen original adjunta por el usuario; se conservó sin editar.

## Resultados del motor y de la integración

En las pruebas P01 a P06, los archivos exactos están en Entradas/Proyecto y la salida ejecutada está en [suite_proyecto_76.txt](Evidencias/suite_proyecto_76.txt).

La notación T/S/E significa tokens, símbolos únicos y errores. Los conteos esperados de P01 a P05 provienen de los resultados históricos contrastados con la especificación y las pruebas. Para P06, el propósito original es comprobar escapes, comentarios y el error # en 26:26; sus conteos completos se registran como resultados medidos, no como una expectativa histórica inventada.

| Caso | Entrada o acción | Salida esperada | Salida obtenida | Estado y evidencia |
| --- | --- | --- | --- | --- |
| P01 | prueba1_sencillo.txt del proyecto | T=25, S=3, E=0; reservadas, identificadores y += clasificados correctamente. | T=25, S=3, E=0. Primera aparición de contador en 5:13. | Aprobado automáticamente; suite_proyecto_76.txt. |
| P02 | prueba2_medio.txt del proyecto | T=62, S=9, E=0; decimal, for y continue reconocidos. | T=62, S=9, E=0. | Aprobado automáticamente; suite_proyecto_76.txt. |
| P03 | prueba3_errores.txt del proyecto | T=20, S=4, E=4. Errores desde 6:13, 9:22, 12:23 y 14:9. El @ dentro del comentario abierto no es otro error. | T=20, S=4, E=4; ubicaciones y diagnósticos esperados. | Aprobado automáticamente; suite_proyecto_76.txt. |
| P04 | prueba4_recuperacion.txt del proyecto | T=21, S=4, E=2; @ en 2:1 y continuación hasta final. | T=21, S=4, E=2; final y despues reconocidos. | Aprobado automáticamente; suite_proyecto_76.txt. |
| P05 | prueba5_categorias.txt del proyecto | T=59, S=7, E=0; categorías previstas presentes. | T=59, S=7, E=0. | Aprobado automáticamente; suite_proyecto_76.txt. |
| P06 | prueba6_interfaz_exportacion.txt original del proyecto | Comentarios con marcadores literales, comentario con salto real, cadenas y caracteres con escapes; exactamente un # inválido en 26:26. | Condiciones aprobadas. Resultados medidos: T=67, S=11, E=1; 30 líneas. | Aprobado automáticamente; suite_proyecto_76.txt. |
| P07 | Nueva prueba 6 de la carpeta documental, en Entradas/Prueba6_nueva | Coincidencia de resultados entre motor, tablas y TXT; un # en 26:26 y reconocimiento posterior de recuperado y return. | T=98, S=15, E=1; 32 líneas. Los 114 registros de las tres tablas exportadas coinciden campo por campo; las 13 categorías suman 98 tokens. | Aprobado mediante prueba de integración y exportación real del usuario; exportacion_real_prueba6_nueva.txt y comprobacion_exportacion_real.txt. |
| P08 | Secuencias inválidas 12.abc, 1..2abc, 12._dato, 12variable, 45.12.3, 1.2abc, 1. y 1..2, seguidas de ; final | Un error por la secuencia inválida completa, ubicación de inicio correcta y reconocimiento de final; sin identificadores artificiales tomados del fragmento inválido. | Coincide para los ocho casos; también se conserva la recuperación con espacio, tabulación, CRLF, LF y +. | Aprobado automáticamente; [numeros_28.txt](Evidencias/numeros_28.txt). |
| P09 | Dígitos ASCII y no ASCII; identificadores niño2, _dato9 y área1 | EsDigito solo admite 0-9; los ejemplos de identificadores mantienen la aceptación prevista; las cifras no ASCII no se convierten en números válidos. | Predicado verificado para los 65536 valores char y casos de reconocimiento aprobados. | Aprobado automáticamente; [digitos_12.txt](Evidencias/digitos_12.txt). |
| P10 | Archivos UTF-8 y UTF-16 LE/BE, vacíos, corruptos, con NUL y UTF-32 | Lectura exacta de codificaciones admitidas; rechazo de NUL y codificaciones inválidas/no admitidas antes de cargar el editor. | 25 comprobaciones aprobadas; incluido NUL inicial, intermedio y posterior a 4096 bytes. El escape literal barra-cero se conserva como código de texto. | Aprobado automáticamente; [carga_25.txt](Evidencias/carga_25.txt). |

## Comprobaciones manuales de la aplicación

| Caso | Acción | Salida esperada | Salida obtenida o confirmación | Estado y evidencia |
| --- | --- | --- | --- | --- |
| M01 | Cargar la nueva prueba 6, analizar y exportar desde la aplicación. | TXT completo del análisis vigente, con campos y escapes conservados. | El usuario generó el archivo y se compararon todos sus registros. | Aprobado; [exportación real](Evidencias/exportacion_real_prueba6_nueva.txt). |
| M02 | Modificar el editor después de analizar. | Tablas y estadísticas invalidadas; exportación deshabilitada; aviso para repetir el análisis. | El usuario confirmó el flujo completo. | Aprobado por confirmación manual en el chat; sin captura específica de esta acción. |
| M03 | Volver a analizar después de editar. | Nuevos resultados vigentes y exportación disponible, sin acumulación de filas. | El usuario confirmó el resultado. | Aprobado por confirmación manual; reanálisis sin acumulación comprobado también en pruebas programáticas anteriores. |
| M04 | Pulsar Limpiar. | Editor y tablas vacíos, contadores en cero y exportación deshabilitada. | El usuario confirmó el resultado. | Aprobado por confirmación manual en el chat. |
| M05 | Abrir Cargar archivo y cancelar tras un análisis válido. | Conservar el código y los resultados existentes. | El usuario confirmó la conservación de la sesión. | Aprobado por confirmación manual en el chat. |
| M06 | Abrir Exportar resultados y cancelar. | Conservar resultados; no crear un archivo ni confirmar una exportación. | El usuario confirmó el resultado esperado. | Aprobado por confirmación manual en el chat. |
| M07 | Superar 120 líneas, desplazarse y revisar el paso de 99 a 100. | Números alineados, línea final correcta y sin numeración superpuesta. | El usuario confirmó la numeración y el desplazamiento. | Aprobado por confirmación manual en el chat; no se afirma una prueba de todas las escalas de Windows. |
| M08 | Maximizar y reducir la ventana. | Editor, pestañas y botones accesibles y sin superposición en los tamaños probados. | El usuario confirmó el resultado. | Aprobado por confirmación manual en el chat. |
| M09 | Repetir var dato = 1; más de 120 veces y analizar. | Sin errores y un solo símbolo dato, aunque el identificador aparezca repetido. | El usuario confirmó la prueba indicada. | Aprobado por confirmación manual en el chat. |
| M10 | Limpiar y pulsar Analizar con editor vacío; repetir con solo espacios. | Mensaje Escribe o carga código antes de analizar; aplicación abierta y sin exportación vigente. | El usuario confirmó que aparece el mensaje en ambos casos. | Aprobado para el mensaje por confirmación manual; no se instrumentó cada control después del aviso. |
| M11 | Intentar cargar Entradas/Archivos_invalidos/utf8_invalido.txt después de analizar la nueva prueba 6. | Rechazo por UTF-8 inválido sin sustituir el código de la sesión. | Captura con el aviso correcto y el código y la tabla de tokens anteriores visibles. | Aprobado para los elementos observables; [captura original del usuario](Evidencias/captura_rechazo_UTF8.png). |

## Compilación y configuración

| Caso | Salida esperada | Resultado | Evidencia |
| --- | --- | --- | --- |
| C01 | Solución completa compilable en Debug. | Aprobado en la copia de los archivos guardados. | [Compilación y configuración](Evidencias/compilacion_y_configuracion.txt). |
| C02 | Solución completa compilable en Release. | Aprobado en la misma copia. | compilacion_y_configuracion.txt. |
| C03 | Proyecto y configuración de ejecución coherentes con .NET Framework 4.8. | csproj con TargetFrameworkVersion v4.8; App.config y ambos exe.config con sku .NETFramework,Version=v4.8 y CLR v4.0. | compilacion_y_configuracion.txt. |

## Comprobaciones que siguen pendientes

| Caso | Qué falta | Estado |
| --- | --- | --- |
| X01 | Copiar una distribución de ejecución completa y probar inicio, carga, análisis y exportación en otro equipo. | Pendiente; no equivale a ejecutar otra copia en este equipo. |
| X02 | Revisar la publicación real del proyecto, el tag/release del Entregable 4 y el historial de participación en Git. | Pendiente de verificar; las consultas locales de Git no pudieron completarse por acceso denegado. |
| X03 | Probar exhaustivamente condiciones de permisos y fallos de escritura, y otras escalas de Windows. | No ejecutado; la matriz no afirma cobertura universal de excepciones o presentación. |

## Interpretación de los resultados

Las correcciones de números inválidos, dígitos y carga de archivos están aplicadas en el código guardado. La exportación real conserva los datos del análisis y los flujos manuales confirmados mantienen el estado esperado del editor y sus resultados.

La suite del proyecto tiene 76 comprobaciones aprobadas. Los conjuntos de carga, números y dígitos tienen 25, 28 y 12 comprobaciones respectivamente. Son conjuntos de aserciones con propósitos y coberturas distintos: no son cantidades de archivos de entrada ni una nota estimada. No se suman aquí como si fueran pruebas completamente independientes.

La prueba 6 original del proyecto y la nueva prueba 6 tienen contenido diferente. Por eso sus conteos completos son diferentes y se conservan en subcarpetas separadas. Para el manual se utilizará preferentemente la nueva prueba de 98 tokens, que coincide con la exportación real y la captura de rechazo de UTF-8 recibidas.

El video sigue aplazado por decisión del usuario. Las pruebas documentadas no sustituyen el manual de uso ni la ejecución en un segundo equipo exigidos por la guía.

## Trazabilidad

Los archivos de entrada y las evidencias se copiaron sin modificar a las subcarpetas Entradas y Evidencias. [manifest_evidencias.json](Evidencias/manifest_evidencias.json) registra sus fuentes y hashes SHA-256. Las confirmaciones manuales proceden de este chat y se distinguen de los registros automáticos y de la captura suministrada.
