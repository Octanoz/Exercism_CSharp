# Instructions

For want of a horseshoe nail, a kingdom was lost, or so the saying goes.

Given a list of inputs, generate the relevant proverb. For example, given the list 
```
["nail", "shoe", "horse", "rider", "message", "battle", "kingdom"]
```
you will output the full text of this proverbial rhyme:

_For want of a nail the shoe was lost._  
_For want of a shoe the horse was lost._  
_For want of a horse the rider was lost._  
_For want of a rider the message was lost._  
_For want of a message the battle was lost._  
_For want of a battle the kingdom was lost._  
_And all for the want of a nail._

Note that the list of inputs may vary; your solution should be able to handle lists of arbitrary length and content. No line of the output text should be a static, unchanging string; all should vary according to the input given.

Try to capture the structure of the song in your code, where you build up the song by composing its parts.