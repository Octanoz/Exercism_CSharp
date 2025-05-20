# Instructions

Implement an evaluator for a very simple subset of Forth.

Forth is a stack-based programming language. Implement a very basic evaluator for a small subset of Forth.

## Rules

Your evaluator has to support the following words:

- +, -, *, / (integer arithmetic)
- DUP
    - Creates a copy of the top element on the stack.
    - Visualized ( l m n -> l m n n )
    - Where `n` represents a stack item
- DROP
    - Discards the top item from the stack.
    - Visualized ( l m n -- l m )
- SWAP
    - Swaps the top two items on the stack.
    - Visualized ( l m n -- l n m )
- OVER
    - Copies the second element and puts it on top of the stack.
    - Visualized ( l m n -- l m n m )


Your evaluator also has to support defining new words using the customary syntax: `: word-name definition ;`.

>To keep things simple the only data type you need to support is **signed integers of at least 16 bits size**

You should use the following rules for the syntax: 

- A number is a sequence of one or more (ASCII) digits
- A word is a sequence of one or more letters, digits, symbols or punctuation that is not a number.
- Words are case-insensitive.

(Forth probably uses slightly different rules, but this is close enough.)

To parse the text, you could try to use the [Sprache](https://github.com/sprache/Sprache/blob/develop/README.md) library. You can also find a good tutorial [here](https://www.thomaslevesque.com/2017/02/23/easy-text-parsing-in-c-with-sprache/).