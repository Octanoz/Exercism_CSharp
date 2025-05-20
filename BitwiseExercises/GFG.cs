using System.Collections;
using System.Text;

namespace BitwiseExercises
{
    public class GFG
    {
        public static void Bin(long number)
        {
            long i;
            Console.Write("0");

            for (i = 1 << 30; i > 0; i >>= 1)
            {
                char bit = (number & i) == i ? '1' : '0';
                Console.Write(bit);
            }
        }

        public static void BinRecursive(int number)
        {
            if (number > 1)
                BinRecursive(number / 2);

            Console.Write(number % 2);
        }

        public static void BinRecursiveBitwise(int number)
        {
            if (number > 1)
                BinRecursiveBitwise(number >>= 1);

            Console.Write(number & 1);
        }

        public static string GetBits(BitArray bits)
        {
            StringBuilder sb = new();

            for (int i = 0; i < 8; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Insert(0, c);
            }

            return sb.ToString();
        }
    }
}