module Interpreter

open Model

let runValue value =
    match value with
    | Number(n) -> n

let runOperation op =
    match op with
    | Addition(v1, v2) -> (runValue v1) + (runValue v2)

let runExpression exp =
    match exp with
    | Value(value) -> runValue value
    | Operation(op) -> runOperation op

let runProgram (ast: SyntasProgram) =
    match ast with
    | Expression(e) -> runExpression e
