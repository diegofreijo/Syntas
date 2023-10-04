module AstTests

open Xunit
open FParsec
open Model
open Parser

let assertSuccess (parser: Parser<'a>) input (expected: 'a) =
    match run parser input with
    | Success(result, _, _) -> Assert.Equal<'a>(expected, result)
    | Failure(errorMsg, _, _) -> Assert.Fail(sprintf "Failure: %s" errorMsg)

[<Fact>]
let ``Parse a number value`` () = Number 42 |> assertSuccess value "42"

[<Fact>]
let ``Parse a number program`` () =
    Number 42 |> Value |> Expression |> assertSuccess program "42"


[<Fact>]
let ``Parse addition expression`` () =
    Addition((Number 3), (Number 2)) |> assertSuccess operation "3+ 2"

[<Fact>]
let ``Parse an addition program`` () =
    ((Number 5), (Number 7))
    |> Addition
    |> Operation
    |> Expression
    |> assertSuccess program "5 +7"
