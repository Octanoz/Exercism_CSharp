## Introduction

You are starting a secret coding club with some friends and friends-of-friends. Not everyone knows each other, so you and your friends have decided to create a secret handshake that you can use to recognize that someone is a member. You don't want anyone who isn't in the know to be able to crack the code.

You've designed the code so that one person says a number between `1` and `31`, and the other person turns it into a series of actions.

# Instructions

Your task is to convert a number between `1` and `31` to a sequence of actions in the secret handshake.

The sequence of actions is chosen by looking at the rightmost five digits of the number once it's been converted to binary. Start at the right-most digit and move left.

The actions for each number place are:

    00001 = wink
    00010 = double blink
    00100 = close your eyes
    01000 = jump
    10000 = Reverse the order of the operations in the secret handshake.

## Examples

Binary for `9` -> `1001`

1. The digit that is farthest to the right is `1`, so the first action is wink.
3. Going left, the next digit is `0`, so there is no double-blink.
4. Going left again, the next digit is `0`, so you leave your eyes open.
5. Going left again, the next digit is `1`, so you jump.

That was the last digit, so the final code is: `wink, jump`

---

Binary for `26` -> `11010`

1. double blink
2. jump
3. reverse actions

The secret handshake for 26 is therefore: `jump, double blink`

#### Note

If you aren't sure what binary is or how it works, check out [this binary tutorial](https://medium.com/basecs/bits-bytes-building-with-binary-13cb4289aafa).

#### Source: [Bert, in Mary Poppins](https://www.imdb.com/title/tt0058331/quotes/?item=qt0437047)