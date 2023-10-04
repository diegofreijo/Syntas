open System
open FParsec
open Model
open Parser
open Interpreter

[<EntryPoint>]
let main(args) =    
    let input = args[0]
    printfn "Input: %A" input

    match run Parser.program input with
    | Success(ast, _, _) -> 
        printfn "AST: %A" ast
        let result = runProgram ast
        printfn "%A" result
    | Failure(errorMsg, _, _) -> 
        printfn "Failure: %s" errorMsg

    0
