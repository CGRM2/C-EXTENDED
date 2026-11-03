# Gu�a para la sustentaci�n de C-Extended

Duraci�n propuesta: 12 minutos, dentro de los 10 a 15 solicitados. Las diapositivas incluyen notas del presentador con los pasos y tiempos. El reparto siguiente es una propuesta de exposici�n, no una atribuci�n de autor�a del c�digo.

## Reparto sugerido

| Integrante | Diapositivas | Tema | Tiempo |
| --- | --- | --- | --- |
| Cristian | 1 a 4 | Objetivo, especificaci�n, expresiones regulares y estados | 3:30 |
| Enrique | 5 a 7 | Arquitectura, recuperaci�n y pruebas | 3:00 |
| Jos� Roberto | 8 a 11 | Demostraci�n, exportaci�n y l�mites | 5:30 |

Todos deben conocer las preguntas b�sicas siguientes. Pueden intercambiar el reparto seg�n lo que realmente trabaj� cada uno.

## Demostraci�n paso a paso

1. Extraer el paquete y abrir `Aplicacion/C-Extended.exe`.
2. Escribir `int numero = 10;` y pulsar F5. Mostrar Tokens y Tabla de s�mbolos.
3. A�adir `if (numero > 0) { numero--; }`. Explicar por qu� numero aparece varias veces en tokens y una vez como s�mbolo.
4. Cambiar a `var x = ;`. Abrir Errores sint�cticos. Hacer doble clic en la fila y explicar que falta una expresi�n.
5. Corregir a `var x = 1;` y volver a analizar.
6. Cambiar a `var x = @;`. Mostrar el error l�xico y que la sintaxis queda pendiente.
7. Pulsar Ctrl+E y guardar un informe TXT con otro nombre. Abrirlo y se�alar los apartados de ambas etapas.
8. Terminar con un caso v�lido y explicar los l�mites del analizador.

La demostraci�n utiliza entradas peque�as para que el docente pueda seguirlas. Las 22 entradas est�n reunidas en `Prueba_Unica_C_Extended.txt`, en la ra�z. Copiar solamente un bloque a la vez para reproducir un caso de la matriz.

## Preguntas b�sicas y respuestas

**�Qu� diferencia hay entre token y lexema?**
El lexema es el texto concreto, por ejemplo `numero`. El token representa ese fragmento con una categor�a y su ubicaci�n. En el proyecto, Token contiene Lexema, TipoToken, Linea y Columna.

**�Qu� hace el analizador l�xico?**
Recorre los caracteres, reconoce secuencias del lenguaje, produce tokens y registra errores l�xicos. Conserva l�nea y columna y registra identificadores �nicos.

**�Qu� hace el sint�ctico?**
Consume los tokens y comprueba su organizaci�n seg�n la gram�tica simplificada. Detecta, por ejemplo, un punto y coma faltante o una expresi�n incompleta.

**�Por qu� no se ejecuta la sintaxis cuando hay errores l�xicos?**
Porque la secuencia de tokens puede estar incompleta. ResultadoAnalisis solo ejecuta el parser si la lista de errores l�xicos est� vac�a.

**�El programa utiliza expresiones regulares?**
Las usa para describir formalmente las reglas en la documentaci�n. El motor reconoce la entrada manualmente con condiciones y ciclos, sin motores Regex ni generadores de analizadores.

**�Qu� significa `(L|_)(L|D|_)*`?**
El primer car�cter es letra o guion bajo. Despu�s pueden aparecer cero o m�s letras, d�gitos o guiones bajos. El asterisco es cerradura de Kleene.

**�Por qu� 12abc es un error?**
Los identificadores no pueden comenzar con d�gitos y un entero no puede continuar inmediatamente con letras. El motor consume la secuencia completa e informa el error.

**�Qu� es m�ximo avance?**
Preferir el lexema v�lido m�s largo en el contexto, por ejemplo reconocer `>=` completo antes de considerar `>` por separado. Los comentarios tambi�n tienen prioridad sobre divisi�n.

**�Se permiten comentarios anidados?**
No. El primero `*/` cierra el comentario. Si queda otro cierre fuera de �l, se informa como cierre sin apertura.

**�Qu� contiene la tabla de s�mbolos?**
Identificadores �nicos con su primera ubicaci�n. La interfaz a�ade declaraciones encontradas por nombre. No resuelve �mbitos ni comprueba tipos o nombres sin declarar.

**�Qu� diferencia hay entre una entrada inv�lida y una prueba fallida?**
Una entrada inv�lida puede ser una prueba aprobada si el programa detecta el error previsto. Una prueba falla cuando el resultado no cumple el criterio esperado.

**�C�mo se verific� la entrega?**
Se ejecutaron 22 casos finales, 76 comprobaciones l�xicas y 125 de sintaxis e integraci�n, todos aprobados. Cada bater�a tiene evidencia. No son 223 archivos diferentes ni una garant�a para cualquier entrada posible.

**�Qu� pasa si se agrega una reservada al diccionario?**
Cambia su clasificaci�n l�xica. No crea una regla sint�ctica nueva.

**�Es un compilador completo de C#?**
No. Reconoce el subconjunto C-Extended y una gram�tica simplificada. No ejecuta c�digo ni valida tipos, �mbitos o referencias a variables.

## Antes de entregar

- Abrir la presentaci�n y revisar sus notas.
- Probar el ejecutable ya extra�do en el equipo donde se presentar�.
- Revisar juntos la memoria y las respuestas anteriores.
- Conservar la memoria PDF, matriz PDF, diapositivas y enlace de la release final.
- Entregar por el medio indicado por el docente. La sustentaci�n presencial y la entrega acad�mica las realiza el grupo.
