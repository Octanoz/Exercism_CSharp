using Forth;

// string[] instructions = [": foo dup ;", ": foo dup dup ;", "1 foo"];
// string[] instructions = [": dup-twice dup dup ;", "1 dup-twice"];
// string[] instructions = [": SWAP DUP Dup dup ;", "1 swap"];
string[] instructions = [": foo 5 ;", ": bar foo ;", ": foo 6 ;", "bar foo"];

Console.WriteLine(ForthMethods.Evaluate(instructions));