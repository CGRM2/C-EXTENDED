# C-Extended — analizador léxico y sintáctico

Proyecto académico C# Windows Forms para el subconjunto C-Extended del curso. El reconocimiento es manual; no usa motores de expresiones regulares ni genera o ejecuta código.

## Abrir y compilar

En Windows, abre **C-Extended.csproj** en Visual Studio con Desarrollo de escritorio de .NET y el paquete de destino **.NET Framework 4.8**. Compila en Release y ejecuta bin/Release/C-Extended.exe. Conserva Manual_de_Uso.txt junto al ejecutable. No hace falta instalar .NET 10 para ejecutar la aplicación.

## Usar

Carga un TXT o escribe código. F5 analiza; también se analiza tras una pausa de 400 ms al editar. Consulta las pestañas de tokens, errores léxicos, errores sintácticos, símbolos y estadísticas. Haz doble clic en una fila para localizarla en el editor. Ctrl+O carga código y Ctrl+E exporta el informe TXT.

Corrige primero los errores léxicos: mientras existan, la sintaxis queda pendiente. Editar o limpiar invalida los resultados de ambas etapas. El informe incluye el estado de cada etapa y no puede sobrescribir el archivo fuente cargado.

El diccionario permite CRUD de clasificaciones léxicas persistentes. Agregar una reservada no crea una regla de gramática. [Manual de uso](Manual_de_Uso.txt) y [gramática y alcance](SINTAXIS.md).

## Pruebas reproducibles

Desde una consola de desarrollador de Visual Studio, en la raíz:

```powershell
msbuild PruebasSintaxis/PruebasSintaxis.csproj /p:Configuration=Release
PruebasSintaxis/bin/Debug/PruebasSintaxis.exe evidencia_sintaxis
msbuild PruebasConsola/PruebasConsola.csproj /p:Configuration=Release
PruebasConsola/bin/Release/PruebasConsola.exe Pruebas
```

El proyecto de sintaxis conserva su ruta de salida bin/Debug incluso con Configuration=Release. Sus pruebas abren brevemente un formulario y guardan una captura y un TXT en la carpeta indicada. La suite léxica guarda su evidencia dentro de Pruebas. Las seis entradas históricas se incluyen en esa carpeta.

## Límites y entrega

No es un compilador completo de C#. No comprueba tipos de valores, resolución de ámbitos, variables sin declarar o nombres duplicados. No acepta toda la sintaxis de C#. Que no haya errores significa que se cumplen las comprobaciones implementadas.

Los documentos bajo Documentacion/Entregable4 y README_Entregable4.md conservan el estado histórico del entregable léxico. Para la versión actual, consulta este README, SINTAXIS.md y Manual_de_Uso.txt. La revisión documental final, el video y la ejecución en otro equipo deben verificarse por separado; las pruebas locales no los sustituyen.

Se utilizó Codex como apoyo para revisar e implementar estas mejoras y ejecutar pruebas.
