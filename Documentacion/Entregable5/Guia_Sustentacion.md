# Guia para la sustentacion de C-Extended

Duracion propuesta: 14 minutos, dentro de los 10 a 15 solicitados. Las diapositivas incluyen notas del presentador con los pasos y tiempos. El reparto siguiente es una propuesta de exposicion, no una atribucion de autoria del codigo.

## Reparto sugerido

| Integrante | Diapositivas | Tema | Tiempo |
| --- | --- | --- | --- |
| Cristian | 1 a 7 | Objetivo, antecedentes, tokens, expresiones regulares y automata | 4:45 |
| Enrique | 8 a 14 | Literales, recuperacion, arquitectura, sintaxis y pruebas | 5:05 |
| Jose Roberto | 15 a 18 | Demostracion, exportacion y conclusiones | 4:10 |

La presentacion contiene 21 diapositivas: 18 principales y 3 de apoyo para preguntas. No es necesario exponer los anexos si no se consultan.

Todos deben conocer las preguntas basicas siguientes. Pueden intercambiar el reparto segun lo que realmente trabajo cada uno.

## Demostracion paso a paso

1. Extraer el paquete y abrir `Aplicacion/C-Extended.exe`.
2. Escribir `int numero = 10;` y pulsar F5. Mostrar Tokens y Tabla de simbolos.
3. Anadir `if (numero > 0) { numero--; }`. Explicar por que numero aparece varias veces en tokens y una vez como simbolo.
4. Cambiar a `var x = ;`. Abrir Errores sintacticos. Hacer doble clic en la fila y explicar que falta una expresion.
5. Corregir a `var x = 1;` y volver a analizar.
6. Cambiar a `var x = @;`. Mostrar el error lexico y que la sintaxis queda pendiente.
7. Pulsar Ctrl+E y guardar un informe TXT con otro nombre. Abrirlo y senalar los apartados de ambas etapas.
8. Terminar con un caso valido y explicar los limites del analizador.

La demostracion utiliza entradas pequenas para que el docente pueda seguirlas. Las 22 entradas estan reunidas en `Prueba_Unica_C_Extended.txt`, en la raiz. Copiar solamente un bloque a la vez para reproducir un caso de la matriz.

## Preguntas basicas y respuestas

**Que diferencia hay entre token y lexema?**
El lexema es el texto concreto, por ejemplo `numero`. El token representa ese fragmento con una categoria y su ubicacion. En el proyecto, Token contiene Lexema, TipoToken, Linea y Columna.

**Que hace el analizador lexico?**
Recorre los caracteres, reconoce secuencias del lenguaje, produce tokens y registra errores lexicos. Conserva linea y columna y registra identificadores unicos.

**Que hace el sintactico?**
Consume los tokens y comprueba su organizacion segun la gramatica simplificada. Detecta, por ejemplo, un punto y coma faltante o una expresion incompleta.

**Por que no se ejecuta la sintaxis cuando hay errores lexicos?**
Porque la secuencia de tokens puede estar incompleta. ResultadoAnalisis solo ejecuta el parser si la lista de errores lexicos esta vacia.

**El programa utiliza expresiones regulares?**
Las usa para describir formalmente las reglas en la documentacion. El motor reconoce la entrada manualmente con condiciones y ciclos, sin motores Regex ni generadores de analizadores.

**Que significa `(L|_)(L|D|_)*`?**
El primer caracter es letra o guion bajo. Despues pueden aparecer cero o mas letras, digitos o guiones bajos. El asterisco es cerradura de Kleene.

**Por que 12abc es un error?**
Los identificadores no pueden comenzar con digitos y un entero no puede continuar inmediatamente con letras. El motor consume la secuencia completa e informa el error.

**Que es maximo avance?**
Preferir el lexema valido mas largo en el contexto, por ejemplo reconocer `>=` completo antes de considerar `>` por separado. Los comentarios tambien tienen prioridad sobre division.

**Se permiten comentarios anidados?**
No. El primero `*/` cierra el comentario. Si queda otro cierre fuera de el, se informa como cierre sin apertura.

**Que contiene la tabla de simbolos?**
Identificadores unicos con su primera ubicacion. La interfaz anade declaraciones encontradas por nombre. No resuelve ambitos ni comprueba tipos o nombres sin declarar.

**Que diferencia hay entre una entrada invalida y una prueba fallida?**
Una entrada invalida puede ser una prueba aprobada si el programa detecta el error previsto. Una prueba falla cuando el resultado no cumple el criterio esperado.

**Como se verifico la entrega?**
Se ejecutaron 22 casos finales, 76 comprobaciones lexicas y 125 de sintaxis e integracion, todos aprobados. Cada bateria tiene evidencia. No son 223 archivos diferentes ni una garantia para cualquier entrada posible.

**Que pasa si se agrega una reservada al diccionario?**
Cambia su clasificacion lexica. No crea una regla sintactica nueva.

**Es un compilador completo de C#?**
No. Reconoce el subconjunto C-Extended y una gramatica simplificada. No ejecuta codigo ni valida tipos, ambitos o referencias a variables.

## Antes de entregar

- Abrir la presentacion y revisar sus notas.
- Probar el ejecutable ya extraido en el equipo donde se presentara.
- Revisar juntos la memoria y las respuestas anteriores.
- Conservar la memoria PDF, matriz PDF, diapositivas y enlace de la release final.
- Entregar por el medio indicado por el docente. La sustentacion presencial y la entrega academica las realiza el grupo.
