using System;

namespace HashMapV2
{

    class Program
    {

        static void Main(string[] args)
        {
            HashMap<int, string> map = new HashMap<int, string>();

            //map.Add(19, "poopy");
            //map.Add(29, "stinky");
            //Console.WriteLine("Enter a key:");
            //int key = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter a value:");
            //string value = Console.ReadLine();
            //map.Add(key, value);

            //Console.WriteLine(map.NumberOfPairs);

            //Console.WriteLine("Enter a key to remove:");
            //key = int.Parse(Console.ReadLine());

            //map.Remove(key);

            string a = "a";
            for (int i = 0; i < 10; i++)
            {
                map.Add(i, a);

                a += "a";
            }

            ;
            map.Add(69, "poopie");



            Console.WriteLine(map.NumberOfPairs);

        }
    }
}
