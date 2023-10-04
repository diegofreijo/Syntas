module Parser

open FParsec
open Model


type Parser<'t> = Parser<'t, unit>

let str = pstring
let ws = spaces

let value: Parser<_> = pfloat |>> Number

let addition = (value .>>. (ws >>. (str "+") >>. ws >>. value)) |>> Addition
let operation = addition


let expression = choice [ attempt operation |>> Operation; value |>> Value ]


let program = expression |>> Expression
