# Informes consolidados de la version ASCII

Las entradas Unicode de la regresion interna se representan con escapes para mantener este archivo en ASCII.

## P01 Declaracion entera

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P01
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 5 ms
Tiempo total        : 5 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     int                                           TK_RESERVADA              1       1
  2     numero                                        TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       12
  4     10                                            TK_NUM_ENTERO             1       14
  5     ;                                             TK_DELIMITADOR            1       16

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  numero | int | variable | 1:5

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     numero                              TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P02 Decimal de muchas cifras

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P02
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_DECIMAL                 : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     double                                        TK_RESERVADA              1       1
  2     pi                                            TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       11
  4     3.141592653589793238462643383279              TK_NUM_DECIMAL            1       13
  5     ;                                             TK_DELIMITADOR            1       45

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  pi | double | variable | 1:8

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     pi                                  TK_IDENTIFICADOR     1               8

=============================================================
  Fin del informe
=============================================================

```

## P03 Identificador largo

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P03
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     identificador_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       1044
  4     1                                             TK_NUM_ENTERO             1       1046
  5     ;                                             TK_DELIMITADOR            1       1047

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  identificador_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa | var | variable | 1:5

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     identificador_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P04 Identificador Unicode

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P04
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     a\u00f1o                                           TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       9
  4     2026                                          TK_NUM_ENTERO             1       11
  5     ;                                             TK_DELIMITADOR            1       15

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  a\u00f1o | var | variable | 1:5

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     a\u00f1o                                 TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P05 Cadena con escapes

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P05
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_CADENA                      : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     string                                        TK_RESERVADA              1       1
  2     texto                                         TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       14
  4     \"Hola\\n\\\"CUNOR\\\"\"                      TK_CADENA                 1       16
  5     ;                                             TK_DELIMITADOR            1       33

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  texto | string | variable | 1:8

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     texto                               TK_IDENTIFICADOR     1               8

=============================================================
  Fin del informe
=============================================================

```

## P06 Caracter con escape

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P06
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_CARACTER                    : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     char                                          TK_RESERVADA              1       1
  2     salto                                         TK_IDENTIFICADOR          1       6
  3     =                                             TK_OP_ASIGNACION          1       12
  4     '\\n'                                         TK_CARACTER               1       14
  5     ;                                             TK_DELIMITADOR            1       18

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  salto | char | variable | 1:6

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     salto                               TK_IDENTIFICADOR     1               6

=============================================================
  Fin del informe
=============================================================

```

## P07 Operadores y control

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P07
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 27
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 5
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 3
  TK_IDENTIFICADOR               : 5
  TK_OP_ASIGNACION               : 2
  TK_NUM_ENTERO                  : 4
  TK_DELIMITADOR                 : 7
  TK_OP_RELACIONAL               : 2
  TK_OP_LOGICO                   : 3
  TK_OP_ARITMETICO               : 1
  TOTAL                          : 27

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     1                                             TK_NUM_ENTERO             1       9
  5     ;                                             TK_DELIMITADOR            1       10
  6     if                                            TK_RESERVADA              1       12
  7     (                                             TK_DELIMITADOR            1       15
  8     x                                             TK_IDENTIFICADOR          1       16
  9     >=                                            TK_OP_RELACIONAL          1       18
  10    1                                             TK_NUM_ENTERO             1       21
  11    &&                                            TK_OP_LOGICO              1       23
  12    x                                             TK_IDENTIFICADOR          1       26
  13    !=                                            TK_OP_RELACIONAL          1       28
  14    2                                             TK_NUM_ENTERO             1       31
  15    ||                                            TK_OP_LOGICO              1       33
  16    !                                             TK_OP_LOGICO              1       36
  17    false                                         TK_RESERVADA              1       37
  18    )                                             TK_DELIMITADOR            1       42
  19    {                                             TK_DELIMITADOR            1       44
  20    x                                             TK_IDENTIFICADOR          1       46
  21    +=                                            TK_OP_ASIGNACION          1       48
  22    2                                             TK_NUM_ENTERO             1       51
  23    ;                                             TK_DELIMITADOR            1       52
  24    x                                             TK_IDENTIFICADOR          1       54
  25    ++                                            TK_OP_ARITMETICO          1       55
  26    ;                                             TK_DELIMITADOR            1       57
  27    }                                             TK_DELIMITADOR            1       59

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  x | var | variable | 1:5

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P08 Comentarios y delimitadores

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P08
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 7
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 2
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_COMENTARIO_LINEA            : 1
  TK_COMENTARIO_BLOQUE           : 1
  TK_RESERVADA                   : 1
  TK_DELIMITADOR                 : 3
  TK_IDENTIFICADOR               : 1
  TOTAL                          : 7

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     // inicio                                     TK_COMENTARIO_LINEA       1       1
  2     /* bloque */                                  TK_COMENTARIO_BLOQUE      2       1
  3     int                                           TK_RESERVADA              2       14
  4     [                                             TK_DELIMITADOR            2       17
  5     ]                                             TK_DELIMITADOR            2       18
  6     datos                                         TK_IDENTIFICADOR          2       20
  7     ;                                             TK_DELIMITADOR            2       25

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  datos | int[] | variable | 2:20

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     datos                               TK_IDENTIFICADOR     2               20

=============================================================
  Fin del informe
=============================================================

```

## P09 Funciones y ciclos

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P09
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 39
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 5
Declaraciones       : 4
Tiempo sintactico   : 1 ms
Tiempo total        : 1 ms
Simbolos unicos     : 4
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 6
  TK_IDENTIFICADOR               : 10
  TK_DELIMITADOR                 : 16
  TK_OP_ARITMETICO               : 2
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 3
  TK_OP_RELACIONAL               : 1
  TOTAL                          : 39

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     func                                          TK_RESERVADA              1       1
  2     sumar                                         TK_IDENTIFICADOR          1       6
  3     (                                             TK_DELIMITADOR            1       11
  4     int                                           TK_RESERVADA              1       12
  5     a                                             TK_IDENTIFICADOR          1       16
  6     ,                                             TK_DELIMITADOR            1       17
  7     int                                           TK_RESERVADA              1       19
  8     b                                             TK_IDENTIFICADOR          1       23
  9     )                                             TK_DELIMITADOR            1       24
  10    {                                             TK_DELIMITADOR            1       26
  11    return                                        TK_RESERVADA              1       28
  12    a                                             TK_IDENTIFICADOR          1       35
  13    +                                             TK_OP_ARITMETICO          1       37
  14    b                                             TK_IDENTIFICADOR          1       39
  15    ;                                             TK_DELIMITADOR            1       40
  16    }                                             TK_DELIMITADOR            1       42
  17    for                                           TK_RESERVADA              1       44
  18    (                                             TK_DELIMITADOR            1       48
  19    var                                           TK_RESERVADA              1       49
  20    i                                             TK_IDENTIFICADOR          1       53
  21    =                                             TK_OP_ASIGNACION          1       54
  22    0                                             TK_NUM_ENTERO             1       55
  23    ;                                             TK_DELIMITADOR            1       56
  24    i                                             TK_IDENTIFICADOR          1       58
  25    <                                             TK_OP_RELACIONAL          1       59
  26    3                                             TK_NUM_ENTERO             1       60
  27    ;                                             TK_DELIMITADOR            1       61
  28    i                                             TK_IDENTIFICADOR          1       63
  29    ++                                            TK_OP_ARITMETICO          1       64
  30    )                                             TK_DELIMITADOR            1       66
  31    {                                             TK_DELIMITADOR            1       68
  32    sumar                                         TK_IDENTIFICADOR          1       70
  33    (                                             TK_DELIMITADOR            1       75
  34    i                                             TK_IDENTIFICADOR          1       76
  35    ,                                             TK_DELIMITADOR            1       77
  36    1                                             TK_NUM_ENTERO             1       79
  37    )                                             TK_DELIMITADOR            1       80
  38    ;                                             TK_DELIMITADOR            1       81
  39    }                                             TK_DELIMITADOR            1       83

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  sumar | func | funcion | 1:6
  a | int | parametro | 1:16
  b | int | parametro | 1:23
  i | var | variable | 1:53

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     sumar                               TK_IDENTIFICADOR     1               6
  2     a                                   TK_IDENTIFICADOR     1               16
  3     b                                   TK_IDENTIFICADOR     1               23
  4     i                                   TK_IDENTIFICADOR     1               53

=============================================================
  Fin del informe
=============================================================

```

## P10 Entrada vacia

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P10
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 0
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 0
Declaraciones       : 0
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 0
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TOTAL                          : 0

--- TOKENS ---
  (no se encontraron tokens)

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No se encontraron declaraciones.

--- TABLA DE SIMBOLOS ---
  (tabla vacia)

=============================================================
  Fin del informe
=============================================================

```

## P11 Errores combinados y recuperacion

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P11
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 17
Total de errores detectados: 3
Errores lexicos      : 3
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 4
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 4
  TK_IDENTIFICADOR               : 4
  TK_OP_ASIGNACION               : 4
  TK_DELIMITADOR                 : 4
  TK_NUM_ENTERO                  : 1
  TOTAL                          : 17

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     ;                                             TK_DELIMITADOR            1       10
  5     var                                           TK_RESERVADA              1       12
  6     y                                             TK_IDENTIFICADOR          1       16
  7     =                                             TK_OP_ASIGNACION          1       18
  8     ;                                             TK_DELIMITADOR            1       25
  9     var                                           TK_RESERVADA              1       27
  10    z                                             TK_IDENTIFICADOR          1       31
  11    =                                             TK_OP_ASIGNACION          1       33
  12    ;                                             TK_DELIMITADOR            1       39
  13    var                                           TK_RESERVADA              1       41
  14    ok                                            TK_IDENTIFICADOR          1       45
  15    =                                             TK_OP_ASIGNACION          1       48
  16    3                                             TK_NUM_ENTERO             1       50
  17    ;                                             TK_DELIMITADOR            1       51

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     @                                        1       9         Caracter no permitido
  2     12abc                                    1       20        Identificador con inicio numerico
  3     1..2                                     1       35        Numero decimal mal formado: falta un digito despues del punto

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5
  2     y                                   TK_IDENTIFICADOR     1               16
  3     z                                   TK_IDENTIFICADOR     1               31
  4     ok                                  TK_IDENTIFICADOR     1               45

=============================================================
  Fin del informe
=============================================================

```

## P12 Cadena sin cerrar recupera linea

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P12
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 8
Total de errores detectados: 1
Errores lexicos      : 1
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 2
Total de lineas     : 2
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 2
  TK_IDENTIFICADOR               : 2
  TK_OP_ASIGNACION               : 2
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 8

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     string                                        TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       10
  4     var                                           TK_RESERVADA              2       1
  5     ok                                            TK_IDENTIFICADOR          2       5
  6     =                                             TK_OP_ASIGNACION          2       8
  7     1                                             TK_NUM_ENTERO             2       10
  8     ;                                             TK_DELIMITADOR            2       11

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     \"sin cierre                             1       12        Cadena de texto sin cerrar

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               8
  2     ok                                  TK_IDENTIFICADOR     2               5

=============================================================
  Fin del informe
=============================================================

```

## P13 Comentario sin cerrar

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P13
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 1
Errores lexicos      : 1
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     int                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     1                                             TK_NUM_ENTERO             1       9
  5     ;                                             TK_DELIMITADOR            1       10

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     /* sin cierre                            1       12        Comentario multilinea sin cerrar

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P14 Comentarios anidados no admitidos

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P14
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 2
Total de errores detectados: 1
Errores lexicos      : 1
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_COMENTARIO_BLOQUE           : 1
  TK_IDENTIFICADOR               : 1
  TOTAL                          : 2

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     /* exterior /* interior */                    TK_COMENTARIO_BLOQUE      1       1
  2     resto                                         TK_IDENTIFICADOR          1       28

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     */                                       1       34        Cierre de comentario sin apertura /*

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     resto                               TK_IDENTIFICADOR     1               28

=============================================================
  Fin del informe
=============================================================

```

## P15 Decimales incompletos

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P15
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 8
Total de errores detectados: 2
Errores lexicos      : 2
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 2
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 2
  TK_IDENTIFICADOR               : 2
  TK_OP_ASIGNACION               : 2
  TK_DELIMITADOR                 : 2
  TOTAL                          : 8

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     a                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     ;                                             TK_DELIMITADOR            1       11
  5     var                                           TK_RESERVADA              1       13
  6     b                                             TK_IDENTIFICADOR          1       17
  7     =                                             TK_OP_ASIGNACION          1       19
  8     ;                                             TK_DELIMITADOR            1       23

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     .5                                       1       9         Numero decimal mal formado: falta un digito antes del punto
  2     1.                                       1       21        Numero decimal mal formado: falta un digito despues del punto

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     a                                   TK_IDENTIFICADOR     1               5
  2     b                                   TK_IDENTIFICADOR     1               17

=============================================================
  Fin del informe
=============================================================

```

## P16 Caracter de longitud invalida

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P16
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 8
Total de errores detectados: 2
Errores lexicos      : 2
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 2
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 2
  TK_IDENTIFICADOR               : 2
  TK_OP_ASIGNACION               : 2
  TK_DELIMITADOR                 : 2
  TOTAL                          : 8

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     char                                          TK_RESERVADA              1       1
  2     a                                             TK_IDENTIFICADOR          1       6
  3     =                                             TK_OP_ASIGNACION          1       8
  4     ;                                             TK_DELIMITADOR            1       12
  5     char                                          TK_RESERVADA              1       14
  6     b                                             TK_IDENTIFICADOR          1       19
  7     =                                             TK_OP_ASIGNACION          1       21
  8     ;                                             TK_DELIMITADOR            1       27

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     ''                                       1       10        Un caracter literal debe contener exactamente un caracter
  2     'ab'                                     1       23        Un caracter literal debe contener exactamente un caracter

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     a                                   TK_IDENTIFICADOR     1               6
  2     b                                   TK_IDENTIFICADOR     1               19

=============================================================
  Fin del informe
=============================================================

```

## P17 Escape invalido

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P17
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 4
Total de errores detectados: 1
Errores lexicos      : 1
Estado sintactico   : Pendiente / no evaluado
Errores sintacticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sintactico   : No evaluado
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 4

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     string                                        TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       10
  4     ;                                             TK_DELIMITADOR            1       16

--- ERRORES LEXICOS ---
  #     Secuencia invalida (escapada)            Linea   Columna   Descripcion
  ----------------------------------------------------------------------------------------------------
  1     \"\\q\"                                  1       12        Secuencia de escape no valida en cadena

--- ERRORES SINTACTICOS ---
  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No evaluadas: analisis sintactico pendiente.

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               8

=============================================================
  Fin del informe
=============================================================

```

## P18 Punto y coma ausente

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P18
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 4
Total de errores detectados: 1
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 1
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TOTAL                          : 4

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     int                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     10                                            TK_NUM_ENTERO             1       9

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  1:11 | fin de archivo | Se esperaba ';'; se encontro 'fin de archivo'.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  x | int | variable | 1:5

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P19 Operando ausente

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P19
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 6
Total de errores detectados: 1
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 1
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_OP_ARITMETICO               : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 6

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     5                                             TK_NUM_ENTERO             1       9
  5     +                                             TK_OP_ARITMETICO          1       11
  6     ;                                             TK_DELIMITADOR            1       13

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  1:13 | ; | Se esperaba una expresion; se encontro ';'.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  x | var | variable | 1:5

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P20 Control fuera de contexto

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P20
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 7
Total de errores detectados: 3
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 3
Estructuras         : 3
Declaraciones       : 0
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 0
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 3
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 3
  TOTAL                          : 7

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     return                                        TK_RESERVADA              1       1
  2     1                                             TK_NUM_ENTERO             1       8
  3     ;                                             TK_DELIMITADOR            1       9
  4     break                                         TK_RESERVADA              1       11
  5     ;                                             TK_DELIMITADOR            1       16
  6     continue                                      TK_RESERVADA              1       18
  7     ;                                             TK_DELIMITADOR            1       26

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  1:8 | 1 | 'return' esta fuera de una funcion.
  1:11 | break | 'break' esta fuera de un ciclo o switch.
  1:18 | continue | 'continue' esta fuera de un ciclo.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  No se encontraron declaraciones.

--- TABLA DE SIMBOLOS ---
  (tabla vacia)

=============================================================
  Fin del informe
=============================================================

```

## P21 Arreglos de tipo propio

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P21
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 7
Total de errores detectados: 0
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 2
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_IDENTIFICADOR               : 2
  TK_DELIMITADOR                 : 5
  TOTAL                          : 7

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     Persona                                       TK_IDENTIFICADOR          1       1
  2     [                                             TK_DELIMITADOR            1       8
  3     ]                                             TK_DELIMITADOR            1       9
  4     [                                             TK_DELIMITADOR            1       10
  5     ]                                             TK_DELIMITADOR            1       11
  6     datos                                         TK_IDENTIFICADOR          1       13
  7     ;                                             TK_DELIMITADOR            1       18

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  datos | Persona[][] | variable | 1:13

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     Persona                             TK_IDENTIFICADOR     1               1
  2     datos                               TK_IDENTIFICADOR     1               13

=============================================================
  Fin del informe
=============================================================

```

## P22 Contexto de funcion independiente

```text
=============================================================
  C-extended | Analizador Lexico y Sintactico - Informe de resultados
  Fecha y hora de analisis   : 2026-11-02 23:55:33
  Fecha y hora de exportacion: 2026-11-02 23:55:33
  Fuente analizada           : P22
=============================================================
  Convencion de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de linea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulacion horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 14
Total de errores detectados: 1
Errores lexicos      : 0
Estado sintactico   : Evaluado
Errores sintacticos : 1
Estructuras         : 4
Declaraciones       : 1
Tiempo sintactico   : 0 ms
Tiempo total        : 0 ms
Simbolos unicos     : 1
Total de lineas     : 1
Tiempo de analisis  : 0 ms

--- TOKENS POR CATEGORIA ---
  TK_RESERVADA                   : 4
  TK_DELIMITADOR                 : 9
  TK_IDENTIFICADOR               : 1
  TOTAL                          : 14

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             Linea   Columna
  -----------------------------------------------------------------------------------------------
  1     while                                         TK_RESERVADA              1       1
  2     (                                             TK_DELIMITADOR            1       7
  3     true                                          TK_RESERVADA              1       8
  4     )                                             TK_DELIMITADOR            1       12
  5     {                                             TK_DELIMITADOR            1       14
  6     func                                          TK_RESERVADA              1       16
  7     f                                             TK_IDENTIFICADOR          1       21
  8     (                                             TK_DELIMITADOR            1       22
  9     )                                             TK_DELIMITADOR            1       23
  10    {                                             TK_DELIMITADOR            1       25
  11    break                                         TK_RESERVADA              1       27
  12    ;                                             TK_DELIMITADOR            1       32
  13    }                                             TK_DELIMITADOR            1       34
  14    }                                             TK_DELIMITADOR            1       36

--- ERRORES LEXICOS ---
  No se encontraron errores lexicos.

--- ERRORES SINTACTICOS ---
  1:27 | break | 'break' esta fuera de un ciclo o switch.

--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---
  f | func | funcion | 1:21

--- TABLA DE SIMBOLOS ---
  #     Identificador                       Tipo de token        Primera linea   Primera columna
  ------------------------------------------------------------------------------------------
  1     f                                   TK_IDENTIFICADOR     1               21

=============================================================
  Fin del informe
=============================================================

```

