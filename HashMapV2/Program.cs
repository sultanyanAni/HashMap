using System;

namespace HashMapV2
{

    class Program
    {
  
        static void Main(string[] args)
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "uhoh");
            map.Add(2, "stinky");
            map.Add(3, "poopy");
            map.Add(4, "hehe");

            Console.WriteLine(map.NumberOfPairs);

        }
    }
}
