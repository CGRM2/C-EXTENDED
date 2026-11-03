# Entregable 4 - C-extended

Aplicacion C# Windows Forms integrada con un analizador lexico manual.

## Compilar y ejecutar

En Windows, abrir C-Extended.csproj en Visual Studio con las herramientas de desarrollo de escritorio de .NET y el paquete de destino de .NET Framework 4.8. Compilar en Release y ejecutar C-Extended.exe desde bin/Release conservando sus archivos asociados. La ejecucion requiere .NET Framework 4.8.

## Documentacion y pruebas

- [Manual de uso en PDF](Documentacion/Entregable4/Manual_de_uso_C_extended.pdf).
- [Matriz de pruebas](Documentacion/Entregable4/Matriz_pruebas_Entregable4.md).
- [Registro de cambios](Documentacion/Entregable4/Cambios_lexicos_y_ajustes_entregables.md).
- Evidencias y entradas de prueba en Documentacion/Entregable4.
- PruebasConsola/PruebasConsola.csproj apunta a .NET Framework 4.8. Compilarlo y ejecutar PruebasConsola.exe indicando la carpeta Pruebas como argumento. El ejecutor escribe su informe en la carpeta indicada.

La copia completa se compilo en Debug y Release. La suite actual produjo 76 aprobadas y 0 fallidas. Las comprobaciones especificas de carga, recuperacion numerica y digitos produjeron 25/25, 28/28 y 12/12; sus coberturas se relacionan y no se suman como pruebas independientes.

Hay dos entradas llamadas prueba6_interfaz_exportacion.txt: la original de Pruebas produce 67 tokens, 11 simbolos y 1 error; la nueva en Documentacion/Entregable4/Entradas/Prueba6_nueva produce 98 tokens, 15 simbolos y 1 error. El manual y la exportacion real corresponden a la nueva.

## Alcance pendiente

Quedan pendientes la comprobacion en otro equipo y el video de demostracion. El AFD documental requiere redibujo conforme a las tablas revisadas. La invalidacion tras una excepcion del motor esta implementada y compila, pero no se provoco ese fallo dinamicamente. Este tag identifica el avance del Entregable 4 y no implica que esas tareas esten completadas.

## Apoyo de IA

Se utilizo Antigravity como apoyo de implementacion y Codex para revision, propuestas de correccion, comprobaciones y documentacion. El grupo aplico los cambios y realizo las pruebas manuales descritas. Se conserva el historial real del repositorio sin atribuir participacion no comprobada.
