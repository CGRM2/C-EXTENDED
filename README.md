# C-Extended - analizador l�xico y sint�ctico

Proyecto acad�mico C# Windows Forms para el subconjunto C-Extended del curso. El reconocimiento es manual; no usa motores de expresiones regulares ni genera o ejecuta c�digo.

## Abrir y compilar

En Windows, abre **C-Extended.csproj** en Visual Studio con Desarrollo de escritorio de .NET y el paquete de destino **.NET Framework 4.8**. Compila en Release y ejecuta bin/Release/C-Extended.exe. Conserva Manual_de_Uso.txt junto al ejecutable. No hace falta instalar .NET 10 para ejecutar la aplicaci�n.

## Usar

Carga un TXT o escribe c�digo. F5 analiza; tambi�n se analiza tras una pausa de 400 ms al editar. Consulta las pesta�as de tokens, errores l�xicos, errores sint�cticos, s�mbolos y estad�sticas. Haz doble clic en una fila para localizarla en el editor. Ctrl+O carga c�digo y Ctrl+E exporta el informe TXT.

Corrige primero los errores l�xicos: mientras existan, la sintaxis queda pendiente. Editar o limpiar invalida los resultados de ambas etapas. El informe incluye el estado de cada etapa y no puede sobrescribir el archivo fuente cargado.

El diccionario permite CRUD de clasificaciones l�xicas persistentes. Agregar una reservada no crea una regla de gram�tica. [Manual de uso](Manual_de_Uso.txt) y [gram�tica y alcance](SINTAXIS.md).

## Pruebas reproducibles

Desde una consola de desarrollador de Visual Studio, en la ra�z:

```powershell
msbuild PruebasSintaxis/PruebasSintaxis.csproj /p:Configuration=Release
PruebasSintaxis/bin/Debug/PruebasSintaxis.exe evidencia_sintaxis
msbuild PruebasConsola/PruebasConsola.csproj /p:Configuration=Release
PruebasConsola/bin/Release/PruebasConsola.exe Pruebas
```

El proyecto de sintaxis conserva su ruta de salida bin/Debug incluso con Configuration=Release. Sus pruebas abren brevemente un formulario y guardan una captura y un TXT en la carpeta indicada. La suite l�xica guarda su evidencia dentro de Pruebas. Las seis entradas hist�ricas se incluyen en esa carpeta.

## L�mites y entrega

No es un compilador completo de C#. No comprueba tipos de valores, resoluci�n de �mbitos, variables sin declarar o nombres duplicados. No acepta toda la sintaxis de C#. Que no haya errores significa que se cumplen las comprobaciones implementadas.

Los documentos bajo Documentacion/Entregable4 y README_Entregable4.md conservan el estado hist�rico del entregable l�xico. Para la versi�n actual, consulta este README, SINTAXIS.md y Manual_de_Uso.txt. La revisi�n documental final, el video y la ejecuci�n en otro equipo deben verificarse por separado; las pruebas locales no los sustituyen.

Se utiliz� Codex como apoyo para revisar e implementar estas mejoras y ejecutar pruebas.

## Entregable 5

La documentaci�n final se encuentra en [Documentacion/Entregable5](Documentacion/Entregable5): memoria con manual t�cnico y manual de usuario, matriz detallada, CSV de resultados, diapositivas y gu�a de sustentaci�n.

La matriz final contiene 22 casos aprobados, con entradas e informes TXT reales. Adem�s, se ejecutaron 76 comprobaciones l�xicas y 125 de sintaxis e integraci�n, todas aprobadas. Las evidencias quedan en Documentacion/Entregable5/Evidencias.

Para repetir los casos finales:

```powershell
msbuild PruebasFinales/PruebasFinales.csproj /p:Configuration=Release
PruebasFinales/bin/Release/PruebasFinales.exe evidencia_final
```

El paquete de entrega incluye el ejecutable con su configuraci�n y manual. Debe extraerse antes de ejecutarlo. La prueba en otra computadora y la sustentaci�n presencial deben realizarlas los integrantes.
