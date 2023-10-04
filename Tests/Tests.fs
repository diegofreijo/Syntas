module AstTests

open System
open Xunit

[<Fact>]
let ``Parse int ok`` () =
    Assert.Equals(parse "42", Int 42)
