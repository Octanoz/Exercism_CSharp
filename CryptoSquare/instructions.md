# Instructions

Implement the classic method for composing secret messages called a square code.

Given an English text, output the encoded version of that text.

## Process

- Normalize Input
    - Remove spaces and punctuation
    - Change message to lowercase.

### Create Square

- Normalized characters are broken into rows
    - The rows can be regarded as forming a rectangle when printed with intervening newlines.

## Examples

    "If man was meant to stay on the ground, god would have given us roots."

### Normalized

    "ifmanwasmeanttostayonthegroundgodwouldhavegivenusroots"

### The Square

The plaintext should be organized into a rectangle with sides equal in size as close as possible. The size of the rectangle should be decided by the length of the message.

If `c` is the number of columns and `r` is the number of rows, then for the rectangle $r \times c$ find the smallest possible integer `c` such that:

- $r \times c >=$ length of message
- $c >= r$
- $c - r <= 1$

Our normalized text is $54$ characters long, dictating a rectangle with $c = 8$ and $r = 7$:

    "ifmanwas"
    "meanttos"
    "tayonthe"
    "groundgo"
    "dwouldha"
    "vegivenu"
    "sroots "

The coded message is obtained by reading the columns from top to bottom starting at the left-most column and finishing at the right-most one.

The message above is coded as:

    "imtgdvsfearwermayoogoanouuiontnnlvtwttddesaohghnsseoau"

## Output

Output the encoded text as a single string separated by spaces in chunks that fill perfect rectangles $(r \times c)$, with `c` chunks of `r` length. For phrases that are `n` characters short of the perfect rectangle, pad each of the last `n` chunks with a trailing space.

    "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau "

> **Note**  
> As shown above the last lines will simply be $r - 1$ long instead of actually adding a trailing space. Chunks are still separated by 1 whitespace.

Notice that were we to stack these, we could visually decode the ciphertext back in to the original message:

    "imtgdvs"
    "fearwer"
    "mayoogo"
    "anouuio"
    "ntnnlvt"
    "wttddes"
    "aohghn "
    "sseoau "

* * *

### Source
[J Dalbey's Programming Practice problems](https://users.csc.calpoly.edu/~jdalbey/103/Projects/ProgrammingPractice.html)