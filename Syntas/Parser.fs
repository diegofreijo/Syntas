module Parser

open FParsec
open Model


type Parser<'t> = Parser<'t, unit>

let str = pstring
let ws = spaces

let value: Parser<_> = pfloat |>> Value.Number

let expression =
    value |>>  Expression.Value

let program = 
    expression |>> SyntasProgram.Expression
