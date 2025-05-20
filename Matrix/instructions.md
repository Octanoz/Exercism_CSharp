# Matrix Instructions

Given a string representing a matrix of numbers, return the rows and columns of that matrix.

So given a string with embedded newlines like these:

    9 8 7
    5 3 2
    6 6 7

Representing this matrix:

|  | ***1*** | ***2*** | ***3*** |
|---|---|---|---|
| ***1*** | 9 | 8 | 7 |
| ***2*** | 5 | 3 | 2 |
| ***3*** | 6 | 6 | 7 |


## Output


- A list of the rows
    - Reading each row left-to-right
    - Moving top-to-bottom across the rows
- A list of the columns
    - Reading each column top-to-bottom
    - Moving from left-to-right.

The rows for our example matrix:

- 9, 8, 7
- 5, 3, 2
- 6, 6, 7

And its columns:

- 9, 5, 6
- 8, 3, 6
- 7, 2, 7

* * *

### Source
[Exercise by the JumpstartLab team for students at The Turing School of Software and Design](https://turing.edu/)