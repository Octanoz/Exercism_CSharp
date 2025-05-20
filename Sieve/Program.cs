// #define BRUTE
#define BIT

using Eratosthenes;

#if BRUTE
int[] inputs = [1, 2, 3, 10, 17, 13, 1000];

for (int i = 0; i < inputs.Length; i++)
{
    int[] primes = Sieve.PrimesSquares(inputs[i]);

    Console.WriteLine($"Primes up to {inputs[i]}:");
    Console.WriteLine(primes.Length is 0 ? "None" : String.Join(", ", primes));
}
#endif

#if BIT
var primeResult = Sieve.PrimesBitSquares(13);
Console.WriteLine($"{String.Join(", ", primeResult)}");
#endif