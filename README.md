# A parser for BNF grammars

The parser is actually a usage of [parsing combinators](https://github.com/asafch/PCfs) written in F#.
The input should be a file that defines a BNF grammar of some sort. The grammar should conform to [this](https://en.wikipedia.org/wiki/Backus%E2%80%93Naur_Form#Further_examples) grammar.

## To-do's

1. Verify correctness of referencing a rule, i.e. can't reference a rule before its definition
2. Transform parsed grammar into a parser for the grammar's language
3. Consider support for EBNF - this may ease the transformation of recursive rules to use many/many1
4. Enhance failure propagation - if the parser failed to match some rule, then the whole grammar is invalid

## License

The MIT License (MIT)

Copyright (c) 2016 Asaf Chelouche

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
