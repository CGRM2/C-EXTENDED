# Pruebas del entregable 5

Los 22 casos verifican categorias y lexemas seleccionados, cantidad de errores lexicos y ejecucion o suspension de la sintaxis. Las entradas invalidas aprueban cuando producen el resultado previsto.

Desde la raiz del proyecto, en una consola de desarrollador de Visual Studio:

```powershell
msbuild PruebasFinales/PruebasFinales.csproj /p:Configuration=Release
PruebasFinales/bin/Release/PruebasFinales.exe evidencia_final
```

El ejecutor escribe `matriz_resultados.json`, 22 archivos de entrada, 22 informes exportados y capturas del formulario. Devuelve codigo 1 si falla algun caso, o 0 si todos aprueban. Utiliza el mismo motor y Exportador que la aplicacion.

P08 comprueba el token int en linea 2, columna 14 despues de un comentario y un salto CRLF. P03 verifica un identificador completo de 1038 caracteres. P14 espera un error porque los comentarios de bloque no se anidan.

Las pruebas dependen de las clasificaciones del diccionario del perfil de Windows. Mantener las reservadas predeterminadas para reproducir la matriz publicada. La suite no edita el diccionario.
