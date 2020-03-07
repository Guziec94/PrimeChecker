using System;
using System.Numerics;

namespace PrimeChecker
{
    class Program
    {
        // 14484968830081
        // 8142915490464301747219
        // 6214962790459424018719016702779392029
        // 451733950718173476224044011901550369947411906560037

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę do sprawdzenia");
            string numberAsString = Console.ReadLine();
            BigInteger numberToCheck = BigInteger.Parse(numberAsString);

            if (numberToCheck == 2 || MillerRabinAlgorithm.IsPrimeMillerRabin(numberToCheck))
            {
                Console.WriteLine("Liczba jest liczbą pierwszą.");
            }
            else
            {
                Console.WriteLine("Liczba jest liczbą złożoną.");
            }
            Console.ReadKey();
        }
    }
}