[<AutoOpen>]
module BNFparser

#load "../PCfs/pc.fsx"
open Pc
open System
open System.IO

let inputFile = "example.bnf"

let parseFile input = File.ReadAllText(input)

//printfn "%A" (System.Environment.GetCommandLineArgs().[2])
let inputContent = parseFile inputFile

let digit = digitChar

let letter = anyOf (['a'..'z']@['A'..'Z']) <?> "letter"

let symbol = anyOf [' '; '-' ; '!' ; '#' ; '$' ; '%' ; '&' ; '(' ; ')' ; '*' ; '+' ; ',' ; '-' ; '.' ; '/' ; ':' ; ';' ; '<' ; '=' ; '>' ; '?' ; '@' ; '[' ; '\\' ; ']' ; '^' ; '_' ; '`' ; '{' ; ';' ; '}' ; '~'] <?> "symbol"

let character = letter <|> digit <|> symbol <?> "character"

let character1 = character <|> pchar ''' <?> "character1"

let character2 = character <|> pchar '\"' <?> "character2"

let text1 = many character1 |>> (List.toArray >> String) <?> "text1"

let text2 = many character2 |>> (List.toArray >> String) <?> "text2"

let quote = pchar '''

let doublequote = pchar '\"'

let literal = (between doublequote text1 doublequote) <|> (between quote text2 quote) <?> "literal"

let rule_char = letter <|> digit <|> pchar '-' <?> "rule-char"

let rule_name = (many1 rule_char |>> (List.toArray >> String)) <|> (letter |>> Char.ToString) <?> "rule-name"

let space = pchar ' '

let opt_whitespace = many space

let term = literal <|> (between (pchar '<') rule_name (pchar '>') ) <?> "term"

// I use many1 instead of the recursion in <list>
let list = many1 (term .>> opt_whitespace)
          <?> "list"

let line_end = many1 (opt_whitespace .>>. pchar '\n')
                <?> "line_end"

// I use many1 instead of the recursion in <expression>
// In the right-hand side of <!> I wrap the list in a list for type safety
let expression = ((many1 (list .>> opt_whitespace .>> pchar '|' .>> opt_whitespace) .>>. list) |>> (fun (listOfLists, lst) -> listOfLists @ [lst]))
                  <|> (list |>> fun res -> [res])
                  <?> "expression"


let rule = opt_whitespace >>. pchar '<' >>. rule_name .>> pchar '>' .>> opt_whitespace .>>
           pstring "::="
           .>> opt_whitespace .>>. expression .>> line_end
           <?> "rule"

let syntax = many1 rule <?> "syntax"
