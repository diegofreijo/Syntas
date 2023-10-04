module Model

type Value = 
    | Number of float
    
type Operation = 
    | Addition of Value * Value

type Expression = 
    | Value of Value
    | Operation of Operation

type SyntasProgram = 
    | Expression of Expression