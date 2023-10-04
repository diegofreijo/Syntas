module InterpreterTests

open Xunit
open FParsec
open Model
open Interpreter

let assertSuccess (runner: 'ast -> 'output) (expected: 'output) (input: 'ast) =
    Assert.Equal<'output>(runner input, expected)

[<Fact>]
let ``Run Single value`` () = Number 42 |> assertSuccess runValue 42

[<Fact>]
let ``Run Addition`` () =
    Addition((Number 1), (Number 2)) |> assertSuccess runOperation 3

[<Fact>]
let ``Run Program`` () =
    Addition((Number 1), (Number 4))
    |> Operation
    |> Expression
    |> assertSuccess runProgram 5
