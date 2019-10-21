using System;

namespace HashMapV2
{

    class Program
    {
        static int Hash(string input)
        {
            int primeNum = 97;

            int hash = 0;

            for (int i = 0; i < input.Length; i++)
            {
                hash += primeNum + input[i] + i;
            }

            return hash;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hey enter something:");
            string blah = Console.ReadLine();

            Console.WriteLine($"Your hash is: {Hash(blah)}");
        }
    }
}
