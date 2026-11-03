# Matriz de pruebas del Entregable 4

Proyecto: C-extended, analizador lexico en C# Windows Forms.

Fecha de consolidacion: 15 de octubre de 2026.

El motor, la integracion y los flujos revisados produjeron los resultados esperados. Esta matriz reune las comprobaciones automaticas, las confirmaciones manuales del usuario y la exportacion generada desde su aplicacion. La ejecucion en otro equipo sigue pendiente; no se presenta como aprobada.

## Alcance de la evidencia

- **Automatica sobre el proyecto:** se compilo una copia completa de los archivos guardados del proyecto de AAA2, incluidos el disenador y los recursos. La comparacion posterior de 19 archivos con la copia verificada no encontro diferencias.
- **Manual confirmada por el usuario:** el usuario realizo las acciones descritas y confirmo su resultado en este chat. Una confirmacion no se presenta como una captura inexistente.
- **Archivo generado por la aplicacion del usuario:** se recibio y se leyo de nuevo el TXT exportado, comparando sus registros con los objetos esperados.
- La captura de rechazo de UTF-8 es la imagen original adjunta por el usuario; se conservo sin editar.

## Resultados del motor y de la integracion

En las pruebas P01 a P06, los archivos exactos estan en Entradas/Proyecto y la salida ejecutada esta en [suite_proyecto_76.txt](Evidencias/suite_proyecto_76.txt).

La notacion T/S/E significa tokens, simbolos unicos y errores. Los conteos esperados de P01 a P05 provienen de los resultados historicos contrastados con la especificacion y las pruebas. Para P06, el proposito original es comprobar escapes, comentarios y el error # en 26:26; sus conteos completos se registran como resultados medidos, no como una expectativa historica inventada.

| Caso | Entrada o accion | Salida esperada | Salida obtenida | Estado y evidencia |
| --- | --- | --- | --- | --- |
| P01 | prueba1_sencillo.txt del proyecto | T=25, S=3, E=0; reservadas, identificadores y += clasificados correctamente. | T=25, S=3, E=0. Primera aparicion de contador en 5:13. | Aprobado automaticamente; suite_proyecto_76.txt. |
| P02 | prueba2_medio.txt del proyecto | T=62, S=9, E=0; decimal, for y continue reconocidos. | T=62, S=9, E=0. | Aprobado automaticamente; suite_proyecto_76.txt. |
| P03 | prueba3_errores.txt del proyecto | T=20, S=4, E=4. Errores desde 6:13, 9:22, 12:23 y 14:9. El @ dentro del comentario abierto no es otro error. | T=20, S=4, E=4; ubicaciones y diagnosticos esperados. | Aprobado automaticamente; suite_proyecto_76.txt. |
| P04 | prueba4_recuperacion.txt del proyecto | T=21, S=4, E=2; @ en 2:1 y continuacion hasta final. | T=21, S=4, E=2; final y despues reconocidos. | Aprobado automaticamente; suite_proyecto_76.txt. |
| P05 | prueba5_categorias.txt del proyecto | T=59, S=7, E=0; categorias previstas presentes. | T=59, S=7, E=0. | Aprobado automaticamente; suite_proyecto_76.txt. |
| P06 | prueba6_interfaz_exportacion.txt original del proyecto | Comentarios con marcadores literales, comentario con salto real, cadenas y caracteres con escapes; exactamente un # invalido en 26:26. | Condiciones aprobadas. Resultados medidos: T=67, S=11, E=1; 30 lineas. | Aprobado automaticamente; suite_proyecto_76.txt. |
| P07 | Nueva prueba 6 de la carpeta documental, en Entradas/Prueba6_nueva | Coincidencia de resultados entre motor, tablas y TXT; un # en 26:26 y reconocimiento posterior de recuperado y return. | T=98, S=15, E=1; 32 lineas. Los 114 registros de las tres tablas exportadas coinciden campo por campo; las 13 categorias suman 98 tokens. | Aprobado mediante prueba de integracion y exportacion real del usuario; exportacion_real_prueba6_nueva.txt y comprobacion_exportacion_real.txt. |
| P08 | Secuencias invalidas 12.abc, 1..2abc, 12._dato, 12variable, 45.12.3, 1.2abc, 1. y 1..2, seguidas de ; final | Un error por la secuencia invalida completa, ubicacion de inicio correcta y reconocimiento de final; sin identificadores artificiales tomados del fragmento invalido. | Coincide para los ocho casos; tambien se conserva la recuperacion con espacio, tabulacion, CRLF, LF y +. | Aprobado automaticamente; [numeros_28.txt](Evidencias/numeros_28.txt). |
| P09 | Digitos ASCII y no ASCII; identificadores nino2, _dato9 y area1 | EsDigito solo admite 0-9; los ejemplos de identificadores mantienen la aceptacion prevista; las cifras no ASCII no se convierten en numeros validos. | Predicado verificado para los 65536 valores char y casos de reconocimiento aprobados. | Aprobado automaticamente; [digitos_12.txt](Evidencias/digitos_12.txt). |
| P10 | Archivos UTF-8 y UTF-16 LE/BE, vacios, corruptos, con NUL y UTF-32 | Lectura exacta de codificaciones admitidas; rechazo de NUL y codificaciones invalidas/no admitidas antes de cargar el editor. | 25 comprobaciones aprobadas; incluido NUL inicial, intermedio y posterior a 4096 bytes. El escape literal barra-cero se conserva como codigo de texto. | Aprobado automaticamente; [carga_25.txt](Evidencias/carga_25.txt). |

## Comprobaciones manuales de la aplicacion

| Caso | Accion | Salida esperada | Salida obtenida o confirmacion | Estado y evidencia |
| --- | --- | --- | --- | --- |
| M01 | Cargar la nueva prueba 6, analizar y exportar desde la aplicacion. | TXT completo del analisis vigente, con campos y escapes conservados. | El usuario genero el archivo y se compararon todos sus registros. | Aprobado; [exportacion real](Evidencias/exportacion_real_prueba6_nueva.txt). |
| M02 | Modificar el editor despues de analizar. | Tablas y estadisticas invalidadas; exportacion deshabilitada; aviso para repetir el analisis. | El usuario confirmo el flujo completo. | Aprobado por confirmacion manual en el chat; sin captura especifica de esta accion. |
| M03 | Volver a analizar despues de editar. | Nuevos resultados vigentes y exportacion disponible, sin acumulacion de filas. | El usuario confirmo el resultado. | Aprobado por confirmacion manual; reanalisis sin acumulacion comprobado tambien en pruebas programaticas anteriores. |
| M04 | Pulsar Limpiar. | Editor y tablas vacios, contadores en cero y exportacion deshabilitada. | El usuario confirmo el resultado. | Aprobado por confirmacion manual en el chat. |
| M05 | Abrir Cargar archivo y cancelar tras un analisis valido. | Conservar el codigo y los resultados existentes. | El usuario confirmo la conservacion de la sesion. | Aprobado por confirmacion manual en el chat. |
| M06 | Abrir Exportar resultados y cancelar. | Conservar resultados; no crear un archivo ni confirmar una exportacion. | El usuario confirmo el resultado esperado. | Aprobado por confirmacion manual en el chat. |
| M07 | Superar 120 lineas, desplazarse y revisar el paso de 99 a 100. | Numeros alineados, linea final correcta y sin numeracion superpuesta. | El usuario confirmo la numeracion y el desplazamiento. | Aprobado por confirmacion manual en el chat; no se afirma una prueba de todas las escalas de Windows. |
| M08 | Maximizar y reducir la ventana. | Editor, pestanas y botones accesibles y sin superposicion en los tamanos probados. | El usuario confirmo el resultado. | Aprobado por confirmacion manual en el chat. |
| M09 | Repetir var dato = 1; mas de 120 veces y analizar. | Sin errores y un solo simbolo dato, aunque el identificador aparezca repetido. | El usuario confirmo la prueba indicada. | Aprobado por confirmacion manual en el chat. |
| M10 | Limpiar y pulsar Analizar con editor vacio; repetir con solo espacios. | Mensaje Escribe o carga codigo antes de analizar; aplicacion abierta y sin exportacion vigente. | El usuario confirmo que aparece el mensaje en ambos casos. | Aprobado para el mensaje por confirmacion manual; no se instrumento cada control despues del aviso. |
| M11 | Intentar cargar Entradas/Archivos_invalidos/utf8_invalido.txt despues de analizar la nueva prueba 6. | Rechazo por UTF-8 invalido sin sustituir el codigo de la sesion. | Captura con el aviso correcto y el codigo y la tabla de tokens anteriores visibles. | Aprobado para los elementos observables; [captura original del usuario](Evidencias/captura_rechazo_UTF8.png). |

## Compilacion y configuracion

| Caso | Salida esperada | Resultado | Evidencia |
| --- | --- | --- | --- |
| C01 | Solucion completa compilable en Debug. | Aprobado en la copia de los archivos guardados. | [Compilacion y configuracion](Evidencias/compilacion_y_configuracion.txt). |
| C02 | Solucion completa compilable en Release. | Aprobado en la misma copia. | compilacion_y_configuracion.txt. |
| C03 | Proyecto y configuracion de ejecucion coherentes con .NET Framework 4.8. | csproj con TargetFrameworkVersion v4.8; App.config y ambos exe.config con sku .NETFramework,Version=v4.8 y CLR v4.0. | compilacion_y_configuracion.txt. |

## Comprobaciones que siguen pendientes

| Caso | Que falta | Estado |
| --- | --- | --- |
| X01 | Copiar una distribucion de ejecucion completa y probar inicio, carga, analisis y exportacion en otro equipo. | Pendiente; no equivale a ejecutar otra copia en este equipo. |
| X02 | Revisar la publicacion real del proyecto, el tag/release del Entregable 4 y el historial de participacion en Git. | Pendiente de verificar; las consultas locales de Git no pudieron completarse por acceso denegado. |
| X03 | Probar exhaustivamente condiciones de permisos y fallos de escritura, y otras escalas de Windows. | No ejecutado; la matriz no afirma cobertura universal de excepciones o presentacion. |

## Interpretacion de los resultados

Las correcciones de numeros invalidos, digitos y carga de archivos estan aplicadas en el codigo guardado. La exportacion real conserva los datos del analisis y los flujos manuales confirmados mantienen el estado esperado del editor y sus resultados.

La suite del proyecto tiene 76 comprobaciones aprobadas. Los conjuntos de carga, numeros y digitos tienen 25, 28 y 12 comprobaciones respectivamente. Son conjuntos de aserciones con propositos y coberturas distintos: no son cantidades de archivos de entrada ni una nota estimada. No se suman aqui como si fueran pruebas completamente independientes.

La prueba 6 original del proyecto y la nueva prueba 6 tienen contenido diferente. Por eso sus conteos completos son diferentes y se conservan en subcarpetas separadas. Para el manual se utilizara preferentemente la nueva prueba de 98 tokens, que coincide con la exportacion real y la captura de rechazo de UTF-8 recibidas.

El video sigue aplazado por decision del usuario. Las pruebas documentadas no sustituyen el manual de uso ni la ejecucion en un segundo equipo exigidos por la guia.

## Trazabilidad

Los archivos de entrada y las evidencias se copiaron sin modificar a las subcarpetas Entradas y Evidencias. [manifest_evidencias.json](Evidencias/manifest_evidencias.json) registra sus fuentes y hashes SHA-256. Las confirmaciones manuales proceden de este chat y se distinguen de los registros automaticos y de la captura suministrada.
