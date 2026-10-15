# Entregable 4 — C-extended

Aplicación C# Windows Forms integrada con un analizador léxico manual.

## Compilar y ejecutar

En Windows, abrir C-Extended.csproj en Visual Studio con las herramientas de desarrollo de escritorio de .NET y el paquete de destino de .NET Framework 4.8. Compilar en Release y ejecutar C-Extended.exe desde bin/Release conservando sus archivos asociados. La ejecución requiere .NET Framework 4.8.

## Documentación y pruebas

- [Manual de uso en PDF](Documentacion/Entregable4/Manual_de_uso_C_extended.pdf).
- [Matriz de pruebas](Documentacion/Entregable4/Matriz_pruebas_Entregable4.md).
- [Registro de cambios](Documentacion/Entregable4/Cambios_lexicos_y_ajustes_entregables.md).
- Evidencias y entradas de prueba en Documentacion/Entregable4.
- PruebasConsola/PruebasConsola.csproj apunta a .NET Framework 4.8. Compilarlo y ejecutar PruebasConsola.exe indicando la carpeta Pruebas como argumento. El ejecutor escribe su informe en la carpeta indicada.

La copia completa se compiló en Debug y Release. La suite actual produjo 76 aprobadas y 0 fallidas. Las comprobaciones específicas de carga, recuperación numérica y dígitos produjeron 25/25, 28/28 y 12/12; sus coberturas se relacionan y no se suman como pruebas independientes.

Hay dos entradas llamadas prueba6_interfaz_exportacion.txt: la original de Pruebas produce 67 tokens, 11 símbolos y 1 error; la nueva en Documentacion/Entregable4/Entradas/Prueba6_nueva produce 98 tokens, 15 símbolos y 1 error. El manual y la exportación real corresponden a la nueva.

## Alcance pendiente

Quedan pendientes la comprobación en otro equipo y el video de demostración. El AFD documental requiere redibujo conforme a las tablas revisadas. La invalidación tras una excepción del motor está implementada y compila, pero no se provocó ese fallo dinámicamente. Este tag identifica el avance del Entregable 4 y no implica que esas tareas estén completadas.

## Apoyo de IA

Se utilizó Antigravity como apoyo de implementación y Codex para revisión, propuestas de corrección, comprobaciones y documentación. El grupo aplicó los cambios y realizó las pruebas manuales descritas. Se conserva el historial real del repositorio sin atribuir participación no comprobada.
