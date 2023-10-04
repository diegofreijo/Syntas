module Tests

open Xunit
open Model
open Parser
open FParsec

let assertSuccess (parser: Parser<'a>) input (expected: 'a) =
    match run parser input with
    | Success(result, _, b) -> Assert.Equal<'a>(expected, result)
    | Failure(errorMsg, _, _) -> Assert.Fail(sprintf "Failure: %s" errorMsg)

[<Fact>]
let ``Parsing a number value`` () =
    let expected = Value.Number 42
    assertSuccess value "42" expected

[<Fact>]
let ``Parsing a number program`` () =
    let expected = Value.Number 42 |> Expression.Value |> SyntasProgram.Expression
    assertSuccess program "42" expected
