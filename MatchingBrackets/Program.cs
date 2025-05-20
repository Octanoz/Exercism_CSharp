/* Instructions
----------------
Given a string containing brackets [], braces {}, parentheses (), or any combination thereof, 
verify that any and all pairs are matched and nested correctly. 
The string may also contain other characters, which for the purposes of this exercise should be ignored.
 */

string input = "[[aaa]]]bbc";

int Ace = input.Where(c => c == 'a').Count();

System.Console.WriteLine(Ace);

System.Console.WriteLine(MatchingBrackets.IsPaired(input));
System.Console.WriteLine(MatchingBrackets.IsPairedStack(input));
