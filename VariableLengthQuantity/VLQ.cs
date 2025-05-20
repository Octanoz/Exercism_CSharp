using System.Text;

public static class VLQ
{
    public static uint[] Encode(uint[] numbers)
    {
        List<uint> result = new();
        List<uint> encodedValuesList = new();
        bool lastByte;
        uint encodedValue, currentNumber, index;

        for (int i = 0; i < numbers.Length; i++)
        {
            currentNumber = numbers[i];
            index = 1;
            lastByte = false;

            do
            {
                encodedValue = currentNumber & 127;
                currentNumber >>= 7;

                if (currentNumber == 0)
                    lastByte = true;

                if (index > 1)
                    encodedValue |= 128;

                encodedValuesList.Add(encodedValue);
                index++;
            } while (!lastByte);

            encodedValuesList.Reverse();
            result.AddRange(encodedValuesList);
            encodedValuesList.Clear();
        }

        return result.ToArray();
    }

    public static uint[] Encode2(uint[] numbers)
    {
        List<uint> result = new();
        List<uint> encodedValuesList = new();

        foreach (uint num in numbers)
        {
            if (num == 0)
                encodedValuesList.Add(num);

            uint currentNumber = num;
            while (currentNumber > 0)
            {
                uint encodedValue = currentNumber & 0x7Fu;
                currentNumber >>= 7;

                if (encodedValuesList.Any())
                    encodedValue |= 0x80u;

                encodedValuesList.Add(encodedValue);
            }

            encodedValuesList.Reverse();
            result.AddRange(encodedValuesList);
            encodedValuesList.Clear();
        }

        return result.ToArray();
    }



    public static uint[] Decode(uint[] bytes)
    {
        List<uint> result = new();
        uint currentValue = 0;
        bool sequenceIsComplete = false;

        foreach (var b in bytes)
        {
            sequenceIsComplete = false;

            if ((b & 0x80u) == 0x80u)
            {
                currentValue += b ^ 0x80u;
                currentValue <<= 7;
            }
            else
            {
                currentValue += b;
                result.Add(currentValue);
                currentValue = 0;
                sequenceIsComplete = true;
            }
        }

        if (!sequenceIsComplete)
            throw new InvalidOperationException();

        return result.ToArray();
    }

    public static uint[] Decode2(uint[] bytes)
    {
        List<uint> result = new();
        uint currentValue = 0;
        bool continuation = false;

        foreach (var b in bytes)
        {
            uint sevenBit = b & 0x7F;

            if (continuation)
            {
                currentValue = (currentValue << 7) | sevenBit;
            }
            else
            {
                currentValue = sevenBit;
            }

            if ((b & 0x80u) == 0)
            {
                result.Add(currentValue);
                currentValue = 0;
                continuation = false;
            }
            else
            {
                continuation = true;
            }
        }

        return result.ToArray();
    }
}
