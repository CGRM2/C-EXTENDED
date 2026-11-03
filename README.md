# C-Extended - analizador lexico y sintactico

Proyecto academico C# Windows Forms para el subconjunto C-Extended del curso. El reconocimiento es manual; no usa motores de expresiones regulares ni genera o ejecuta codigo.

## Abrir y compilar

En Windows, abre **C-Extended.csproj** en Visual Studio con Desarrollo de escritorio de .NET y el paquete de destino **.NET Framework 4.8**. Compila en Release y ejecuta bin/Release/C-Extended.exe. Conserva Manual_de_Uso.txt junto al ejecutable. No hace falta instalar .NET 10 para ejecutar la aplicacion.

## Usar

Carga un TXT o escribe codigo. F5 analiza; tambien se analiza tras una pausa de 400 ms al editar. Consulta las pestanas de tokens, errores lexicos, errores sintacticos, simbolos y estadisticas. Haz doble clic en una fila para localizarla en el editor. Ctrl+O carga codigo y Ctrl+E exporta el informe TXT.

Corrige primero los errores lexicos: mientras existan, la sintaxis queda pendiente. Editar o limpiar invalida los resultados de ambas etapas. El informe incluye el estado de cada etapa y no puede sobrescribir el archivo fuente cargado.

El diccionario permite CRUD de clasificaciones lexicas persistentes. Agregar una reservada no crea una regla de gramatica. [Manual de uso](Manual_de_Uso.txt) y [gramatica y alcance](SINTAXIS.md).

## Pruebas reproducibles

Desde una consola de desarrollador de Visual Studio, en la raiz:

```powershell
msbuild PruebasSintaxis/PruebasSintaxis.csproj /p:Configuration=Release
PruebasSintaxis/bin/Debug/PruebasSintaxis.exe evidencia_sintaxis
msbuild PruebasConsola/PruebasConsola.csproj /p:Configuration=Release
PruebasConsola/bin/Release/PruebasConsola.exe Pruebas
```

El proyecto de sintaxis conserva su ruta de salida bin/Debug incluso con Configuration=Release. Sus pruebas abren brevemente un formulario y guardan una captura y un TXT en la carpeta indicada. La suite lexica guarda su evidencia dentro de Pruebas. Las seis entradas historicas se incluyen en esa carpeta.

## Limites y entrega

No es un compilador completo de C#. No comprueba tipos de valores, resolucion de ambitos, variables sin declarar o nombres duplicados. No acepta toda la sintaxis de C#. Que no haya errores significa que se cumplen las comprobaciones implementadas.

Los documentos bajo Documentacion/Entregable4 y README_Entregable4.md conservan el estado historico del entregable lexico. Para la version actual, consulta este README, SINTAXIS.md y Manual_de_Uso.txt. La revision documental final, el video y la ejecucion en otro equipo deben verificarse por separado; las pruebas locales no los sustituyen.

Se utilizo Codex como apoyo para revisar e implementar estas mejoras y ejecutar pruebas.

## Entregable 5

La documentacion final se encuentra en [Documentacion/Entregable5](Documentacion/Entregable5): memoria con manual tecnico y manual de usuario, matriz detallada, CSV de resultados, diapositivas y guia de sustentacion.

La matriz final contiene 22 casos aprobados, con entradas e informes TXT reales. Ademas, se ejecutaron 76 comprobaciones lexicas y 125 de sintaxis e integracion, todas aprobadas. Las evidencias quedan en Documentacion/Entregable5/Evidencias.

Para repetir los casos finales:

```powershell
msbuild PruebasFinales/PruebasFinales.csproj /p:Configuration=Release
PruebasFinales/bin/Release/PruebasFinales.exe evidencia_final
```

El paquete de entrega incluye el ejecutable con su configuracion y manual. Debe extraerse antes de ejecutarlo. La prueba en otra computadora y la sustentacion presencial deben realizarlas los integrantes.
