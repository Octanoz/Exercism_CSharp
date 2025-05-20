# Instructions

Your task is to look for patterns in the long sequence of digits in the encrypted signal.

>The technique you're going to use here is called the largest series product.

## Terms

- input: the sequence of digits that you need to analyze
- series: a sequence of adjacent digits (those that are next to each other) that is contained within the input
- span: how many digits long each series is
- product: what you get when you multiply numbers together

## Example

- Input is "63915".
- If you are working with a span of 3, there will be three possible series
    - `639`
    - `391`
    - `915`
- Calculate the product of each series
    - Product of `639` is `162` (`6` × `3` × `9` = `162`)
    - Product of `391` is `27` (`3` × `9` × `1` = `27`)
    - Product of `915` is `45` (`9` × `1` × `5` = `45`)

`162` is bigger than both `27` and `45`, so the largest series product of `63915` is from the series `639`. <br>
So the answer is `162`.