using System;
using System.Collections;
using System.Numerics;

namespace PrimeChecker
{
    public static class RandomNumberGenerator
    {
        public static BigInteger GenerateRandom(BigInteger min, BigInteger max)
        {
            byte[] maxBytes = max.ToByteArray();
            BitArray maxBits = new BitArray(maxBytes);
            Random randomGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < maxBits.Length; i++)
            {
                maxBits[i] = randomGenerator.Next(0, 1) == 0;
            }

            BigInteger result = new BigInteger();

            for (int k = maxBits.Count - 1; k >= 0; k--)
            {
                BigInteger bitValue = 0;

                if (maxBits[k])
                {
                    bitValue = BigInteger.Pow(2, k);
                }

                result = BigInteger.Add(result, bitValue);
            }

            return result;
        }
    }
}