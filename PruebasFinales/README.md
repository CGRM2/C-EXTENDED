# Pruebas del entregable 5

Los 22 casos verifican categor�as y lexemas seleccionados, cantidad de errores l�xicos y ejecuci�n o suspensi�n de la sintaxis. Las entradas inv�lidas aprueban cuando producen el resultado previsto.

Desde la ra�z del proyecto, en una consola de desarrollador de Visual Studio:

```powershell
msbuild PruebasFinales/PruebasFinales.csproj /p:Configuration=Release
PruebasFinales/bin/Release/PruebasFinales.exe evidencia_final
```

El ejecutor escribe `matriz_resultados.json`, 22 archivos de entrada, 22 informes exportados y capturas del formulario. Devuelve c�digo 1 si falla alg�n caso, o 0 si todos aprueban. Utiliza el mismo motor y Exportador que la aplicaci�n.

P08 comprueba el token int en l�nea 2, columna 14 despu�s de un comentario y un salto CRLF. P03 verifica un identificador completo de 1038 caracteres. P14 espera un error porque los comentarios de bloque no se anidan.

Las pruebas dependen de las clasificaciones del diccionario del perfil de Windows. Mantener las reservadas predeterminadas para reproducir la matriz publicada. La suite no edita el diccionario.
