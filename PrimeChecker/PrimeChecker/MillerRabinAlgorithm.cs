using System.Collections.Generic;
using System.Numerics;
using System.Collections;

namespace PrimeChecker
{
    public static class MillerRabinAlgorithm
    {
        public static bool IsPrimeMillerRabin(BigInteger numberToCheck, int iterationCount = 4000)
        {
            BigInteger nMinusOne = BigInteger.Subtract(numberToCheck, 1);

            for (int j = 1; j <= iterationCount; j++)
            {
                BigInteger a = RandomNumberGenerator.GenerateRandom(2, nMinusOne);

                if (Witness(a, numberToCheck))
                {
                    return false;
                }
            }

            return true;
        }

        static bool Witness(BigInteger a, BigInteger n)
        {
            KeyValuePair<int, BigInteger> tAndU = GetTAndU(BigInteger.Subtract(n, 1));
            int t = tAndU.Key;
            BigInteger u = tAndU.Value;
            BigInteger[] x = new BigInteger[t + 1];

            x[0] = BigInteger.ModPow(a, u, n);

            for (int i = 1; i <= t; i++)
            {
                x[i] = BigInteger.ModPow(BigInteger.Multiply(x[i - 1], x[i - 1]), 1, n);
                BigInteger minus = BigInteger.Subtract(x[i - 1], BigInteger.Subtract(n, 1));

                if (x[i] == 1 && x[i - 1] != 1 && !minus.IsZero)
                {
                    return true;
                }
            }

            if (!x[t].IsOne)
            {
                return true;
            }

            return false;
        }

        static KeyValuePair<int, BigInteger> GetTAndU(BigInteger nMinusOne)
        {
            byte[] nBytes = nMinusOne.ToByteArray();
            BitArray bits = new BitArray(nBytes);
            int t = 0;
            BigInteger u = new BigInteger();

            int n = bits.Count - 1;
            bool lastBit = bits[n];

            while (!lastBit)
            {
                t++;
                n--;
                lastBit = bits[n];
            }

            for (int k = bits.Count - 1 - t; k >= 0; k--)
            {
                BigInteger bitValue = 0;

                if (bits[k])
                {
                    bitValue = BigInteger.Pow(2, k);
                }

                u = BigInteger.Add(u, bitValue);
            }

            return new KeyValuePair<int, BigInteger>(t, u);
        }
    }
}