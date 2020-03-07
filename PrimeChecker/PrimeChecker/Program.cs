using System;
using System.Numerics;

namespace PrimeChecker
{
    class Program
    {
        // 14484968830081
        // 8142915490464301747219
        // 6214962790459424018719016702779392029

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę do sprawdzenia");
            string numberAsString = Console.ReadLine();
            BigInteger numberToCheck = BigInteger.Parse(numberAsString);
            if (CheckIfNumberIsPrime(numberToCheck))
            {
                Console.WriteLine("Liczba jest liczbą pierwszą.");
            }
            else
            {
                Console.WriteLine("Liczba jest liczbą złożoną.");
            }
            Console.ReadKey();
        }

        static bool CheckIfNumberIsPrime(BigInteger numberToCheck)
        {
            if (numberToCheck.IsEven && numberToCheck > 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
