# Informes originales consolidados

Cada apartado conserva el informe de un caso ejecutado independientemente.

## P01 Declaraci�n entera

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P01
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 7 ms
Tiempo total        : 7 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     int                                           TK_RESERVADA              1       1
  2     numero                                        TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       12
  4     10                                            TK_NUM_ENTERO             1       14
  5     ;                                             TK_DELIMITADOR            1       16

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  numero | int | variable | 1:5

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     numero                              TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P02 Decimal de muchas cifras

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P02
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_DECIMAL                 : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     double                                        TK_RESERVADA              1       1
  2     pi                                            TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       11
  4     3.141592653589793238462643383279              TK_NUM_DECIMAL            1       13
  5     ;                                             TK_DELIMITADOR            1       45

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  pi | double | variable | 1:8

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     pi                                  TK_IDENTIFICADOR     1               8

=============================================================
  Fin del informe
=============================================================

```

## P03 Identificador largo

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P03
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     identificador_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       1044
  4     1                                             TK_NUM_ENTERO             1       1046
  5     ;                                             TK_DELIMITADOR            1       1047

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  identificador_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa | var | variable | 1:5

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     identificador_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P04 Identificador Unicode

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P04
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     a�o                                           TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       9
  4     2026                                          TK_NUM_ENTERO             1       11
  5     ;                                             TK_DELIMITADOR            1       15

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  a�o | var | variable | 1:5

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     a�o                                 TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P05 Cadena con escapes

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P05
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_CADENA                      : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     string                                        TK_RESERVADA              1       1
  2     texto                                         TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       14
  4     \"Hola\\n\\\"CUNOR\\\"\"                      TK_CADENA                 1       16
  5     ;                                             TK_DELIMITADOR            1       33

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  texto | string | variable | 1:8

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     texto                               TK_IDENTIFICADOR     1               8

=============================================================
  Fin del informe
=============================================================

```

## P06 Car�cter con escape

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P06
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_CARACTER                    : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     char                                          TK_RESERVADA              1       1
  2     salto                                         TK_IDENTIFICADOR          1       6
  3     =                                             TK_OP_ASIGNACION          1       12
  4     '\\n'                                         TK_CARACTER               1       14
  5     ;                                             TK_DELIMITADOR            1       18

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  salto | char | variable | 1:6

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     salto                               TK_IDENTIFICADOR     1               6

=============================================================
  Fin del informe
=============================================================

```

## P07 Operadores y control

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P07
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 27
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 5
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
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
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
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

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  x | var | variable | 1:5

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P08 Comentarios y delimitadores

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P08
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 7
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 2
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_COMENTARIO_LINEA            : 1
  TK_COMENTARIO_BLOQUE           : 1
  TK_RESERVADA                   : 1
  TK_DELIMITADOR                 : 3
  TK_IDENTIFICADOR               : 1
  TOTAL                          : 7

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     // inicio                                     TK_COMENTARIO_LINEA       1       1
  2     /* bloque */                                  TK_COMENTARIO_BLOQUE      2       1
  3     int                                           TK_RESERVADA              2       14
  4     [                                             TK_DELIMITADOR            2       17
  5     ]                                             TK_DELIMITADOR            2       18
  6     datos                                         TK_IDENTIFICADOR          2       20
  7     ;                                             TK_DELIMITADOR            2       25

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  datos | int[] | variable | 2:20

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     datos                               TK_IDENTIFICADOR     2               20

=============================================================
  Fin del informe
=============================================================

```

## P09 Funciones y ciclos

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P09
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 39
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 5
Declaraciones       : 4
Tiempo sint�ctico   : 1 ms
Tiempo total        : 1 ms
S�mbolos �nicos     : 4
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 6
  TK_IDENTIFICADOR               : 10
  TK_DELIMITADOR                 : 16
  TK_OP_ARITMETICO               : 2
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 3
  TK_OP_RELACIONAL               : 1
  TOTAL                          : 39

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
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

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  sumar | func | funci�n | 1:6
  a | int | par�metro | 1:16
  b | int | par�metro | 1:23
  i | var | variable | 1:53

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     sumar                               TK_IDENTIFICADOR     1               6
  2     a                                   TK_IDENTIFICADOR     1               16
  3     b                                   TK_IDENTIFICADOR     1               23
  4     i                                   TK_IDENTIFICADOR     1               53

=============================================================
  Fin del informe
=============================================================

```

## P10 Entrada vac�a

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P10
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 0
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 0
Declaraciones       : 0
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 0
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TOTAL                          : 0

--- TOKENS ---
  (no se encontraron tokens)

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No se encontraron declaraciones.

--- TABLA DE S�MBOLOS ---
  (tabla vac�a)

=============================================================
  Fin del informe
=============================================================

```

## P11 Errores combinados y recuperaci�n

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P11
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 17
Total de errores detectados: 3
Errores l�xicos      : 3
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 4
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 4
  TK_IDENTIFICADOR               : 4
  TK_OP_ASIGNACION               : 4
  TK_DELIMITADOR                 : 4
  TK_NUM_ENTERO                  : 1
  TOTAL                          : 17

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
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

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     @                                        1       9         Car�cter no permitido
  2     12abc                                    1       20        Identificador con inicio num�rico
  3     1..2                                     1       35        N�mero decimal mal formado: falta un d�gito despu�s del punto

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5
  2     y                                   TK_IDENTIFICADOR     1               16
  3     z                                   TK_IDENTIFICADOR     1               31
  4     ok                                  TK_IDENTIFICADOR     1               45

=============================================================
  Fin del informe
=============================================================

```

## P12 Cadena sin cerrar recupera l�nea

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P12
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 8
Total de errores detectados: 1
Errores l�xicos      : 1
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 2
Total de l�neas     : 2
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 2
  TK_IDENTIFICADOR               : 2
  TK_OP_ASIGNACION               : 2
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 8

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     string                                        TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       10
  4     var                                           TK_RESERVADA              2       1
  5     ok                                            TK_IDENTIFICADOR          2       5
  6     =                                             TK_OP_ASIGNACION          2       8
  7     1                                             TK_NUM_ENTERO             2       10
  8     ;                                             TK_DELIMITADOR            2       11

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     \"sin cierre                             1       12        Cadena de texto sin cerrar

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
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
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P13
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 5
Total de errores detectados: 1
Errores l�xicos      : 1
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 5

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     int                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     1                                             TK_NUM_ENTERO             1       9
  5     ;                                             TK_DELIMITADOR            1       10

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     /* sin cierre                            1       12        Comentario multil�nea sin cerrar

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P14 Comentarios anidados no admitidos

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P14
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 2
Total de errores detectados: 1
Errores l�xicos      : 1
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_COMENTARIO_BLOQUE           : 1
  TK_IDENTIFICADOR               : 1
  TOTAL                          : 2

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     /* exterior /* interior */                    TK_COMENTARIO_BLOQUE      1       1
  2     resto                                         TK_IDENTIFICADOR          1       28

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     */                                       1       34        Cierre de comentario sin apertura /*

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     resto                               TK_IDENTIFICADOR     1               28

=============================================================
  Fin del informe
=============================================================

```

## P15 Decimales incompletos

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P15
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 8
Total de errores detectados: 2
Errores l�xicos      : 2
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 2
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 2
  TK_IDENTIFICADOR               : 2
  TK_OP_ASIGNACION               : 2
  TK_DELIMITADOR                 : 2
  TOTAL                          : 8

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     a                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     ;                                             TK_DELIMITADOR            1       11
  5     var                                           TK_RESERVADA              1       13
  6     b                                             TK_IDENTIFICADOR          1       17
  7     =                                             TK_OP_ASIGNACION          1       19
  8     ;                                             TK_DELIMITADOR            1       23

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     .5                                       1       9         N�mero decimal mal formado: falta un d�gito antes del punto
  2     1.                                       1       21        N�mero decimal mal formado: falta un d�gito despu�s del punto

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     a                                   TK_IDENTIFICADOR     1               5
  2     b                                   TK_IDENTIFICADOR     1               17

=============================================================
  Fin del informe
=============================================================

```

## P16 Car�cter de longitud inv�lida

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P16
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 8
Total de errores detectados: 2
Errores l�xicos      : 2
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 2
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 2
  TK_IDENTIFICADOR               : 2
  TK_OP_ASIGNACION               : 2
  TK_DELIMITADOR                 : 2
  TOTAL                          : 8

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     char                                          TK_RESERVADA              1       1
  2     a                                             TK_IDENTIFICADOR          1       6
  3     =                                             TK_OP_ASIGNACION          1       8
  4     ;                                             TK_DELIMITADOR            1       12
  5     char                                          TK_RESERVADA              1       14
  6     b                                             TK_IDENTIFICADOR          1       19
  7     =                                             TK_OP_ASIGNACION          1       21
  8     ;                                             TK_DELIMITADOR            1       27

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     ''                                       1       10        Un car�cter literal debe contener exactamente un car�cter
  2     'ab'                                     1       23        Un car�cter literal debe contener exactamente un car�cter

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     a                                   TK_IDENTIFICADOR     1               6
  2     b                                   TK_IDENTIFICADOR     1               19

=============================================================
  Fin del informe
=============================================================

```

## P17 Escape inv�lido

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P17
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 4
Total de errores detectados: 1
Errores l�xicos      : 1
Estado sint�ctico   : Pendiente / no evaluado
Errores sint�cticos : No evaluados
Estructuras         : No evaluadas
Declaraciones       : No evaluadas
Tiempo sint�ctico   : No evaluado
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 4

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     string                                        TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       8
  3     =                                             TK_OP_ASIGNACION          1       10
  4     ;                                             TK_DELIMITADOR            1       16

--- ERRORES L�XICOS ---
  #     Secuencia inv�lida (escapada)            L�nea   Columna   Descripci�n
  ----------------------------------------------------------------------------------------------------
  1     \"\\q\"                                  1       12        Secuencia de escape no v�lida en cadena

--- ERRORES SINT�CTICOS ---
  An�lisis sint�ctico pendiente / no evaluado. Corrige primero los errores l�xicos si existen.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No evaluadas: an�lisis sint�ctico pendiente.

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               8

=============================================================
  Fin del informe
=============================================================

```

## P18 Punto y coma ausente

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P18
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 4
Total de errores detectados: 1
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 1
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TOTAL                          : 4

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     int                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     10                                            TK_NUM_ENTERO             1       9

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  1:11 | fin de archivo | Se esperaba ';'; se encontr� 'fin de archivo'.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  x | int | variable | 1:5

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P19 Operando ausente

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P19
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 6
Total de errores detectados: 1
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 1
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 1
  TK_IDENTIFICADOR               : 1
  TK_OP_ASIGNACION               : 1
  TK_NUM_ENTERO                  : 1
  TK_OP_ARITMETICO               : 1
  TK_DELIMITADOR                 : 1
  TOTAL                          : 6

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     var                                           TK_RESERVADA              1       1
  2     x                                             TK_IDENTIFICADOR          1       5
  3     =                                             TK_OP_ASIGNACION          1       7
  4     5                                             TK_NUM_ENTERO             1       9
  5     +                                             TK_OP_ARITMETICO          1       11
  6     ;                                             TK_DELIMITADOR            1       13

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  1:13 | ; | Se esperaba una expresi�n; se encontr� ';'.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  x | var | variable | 1:5

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     x                                   TK_IDENTIFICADOR     1               5

=============================================================
  Fin del informe
=============================================================

```

## P20 Control fuera de contexto

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P20
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 7
Total de errores detectados: 3
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 3
Estructuras         : 3
Declaraciones       : 0
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 0
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 3
  TK_NUM_ENTERO                  : 1
  TK_DELIMITADOR                 : 3
  TOTAL                          : 7

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     return                                        TK_RESERVADA              1       1
  2     1                                             TK_NUM_ENTERO             1       8
  3     ;                                             TK_DELIMITADOR            1       9
  4     break                                         TK_RESERVADA              1       11
  5     ;                                             TK_DELIMITADOR            1       16
  6     continue                                      TK_RESERVADA              1       18
  7     ;                                             TK_DELIMITADOR            1       26

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  1:8 | 1 | 'return' est� fuera de una funci�n.
  1:11 | break | 'break' est� fuera de un ciclo o switch.
  1:18 | continue | 'continue' est� fuera de un ciclo.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  No se encontraron declaraciones.

--- TABLA DE S�MBOLOS ---
  (tabla vac�a)

=============================================================
  Fin del informe
=============================================================

```

## P21 Arreglos de tipo propio

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P21
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 7
Total de errores detectados: 0
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 0
Estructuras         : 1
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 2
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_IDENTIFICADOR               : 2
  TK_DELIMITADOR                 : 5
  TOTAL                          : 7

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
  -----------------------------------------------------------------------------------------------
  1     Persona                                       TK_IDENTIFICADOR          1       1
  2     [                                             TK_DELIMITADOR            1       8
  3     ]                                             TK_DELIMITADOR            1       9
  4     [                                             TK_DELIMITADOR            1       10
  5     ]                                             TK_DELIMITADOR            1       11
  6     datos                                         TK_IDENTIFICADOR          1       13
  7     ;                                             TK_DELIMITADOR            1       18

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  Sin errores seg�n la gram�tica de C-Extended. No se verifican tipos ni nombres declarados.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  datos | Persona[][] | variable | 1:13

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     Persona                             TK_IDENTIFICADOR     1               1
  2     datos                               TK_IDENTIFICADOR     1               13

=============================================================
  Fin del informe
=============================================================

```

## P22 Contexto de funci�n independiente

```text
=============================================================
  C-extended | Analizador L�xico y Sint�ctico - Informe de resultados
  Fecha y hora de an�lisis   : 2026-11-02 23:11:04
  Fecha y hora de exportaci�n: 2026-11-02 23:11:04
  Fuente analizada           : P22
=============================================================
  Convenci�n de escape reversible aplicada:
    '\\'     -> barra invertida literal (\)
    '\n'     -> salto de l�nea (LF)
    '\r'     -> retorno de carro (CR)
    '\t'     -> tabulaci�n horizontal
    '\"'    -> comilla doble (")
    '\0'     -> byte nulo
    '\uXXXX' -> c�digo Unicode hexadecimal para otros caracteres de control
=============================================================

--- RESUMEN ---
Total de tokens     : 14
Total de errores detectados: 1
Errores l�xicos      : 0
Estado sint�ctico   : Evaluado
Errores sint�cticos : 1
Estructuras         : 4
Declaraciones       : 1
Tiempo sint�ctico   : 0 ms
Tiempo total        : 0 ms
S�mbolos �nicos     : 1
Total de l�neas     : 1
Tiempo de an�lisis  : 0 ms

--- TOKENS POR CATEGOR�A ---
  TK_RESERVADA                   : 4
  TK_DELIMITADOR                 : 9
  TK_IDENTIFICADOR               : 1
  TOTAL                          : 14

--- TOKENS ---
  #     Lexema (escapado)                             Tipo de token             L�nea   Columna
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

--- ERRORES L�XICOS ---
  No se encontraron errores l�xicos.

--- ERRORES SINT�CTICOS ---
  1:27 | break | 'break' est� fuera de un ciclo o switch.

--- DECLARACIONES SINT�CTICAS ENCONTRADAS (SIN RESOLUCI�N DE �MBITOS) ---
  f | func | funci�n | 1:21

--- TABLA DE S�MBOLOS ---
  #     Identificador                       Tipo de token        Primera l�nea   Primera columna
  ------------------------------------------------------------------------------------------
  1     f                                   TK_IDENTIFICADOR     1               21

=============================================================
  Fin del informe
=============================================================

```

