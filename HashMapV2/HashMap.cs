using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace HashMapV2
{
    public class HashMap<TKey, TValue>
    {
        LinkedList<Pair<TKey, TValue>>[] Collection;
        public int Count => Collection.Length;

        /// <summary>
        /// takes in a string and returns the hash value 
        /// </summary>
        /// <param name="input">string to hash</param>
        /// <returns>hash value</returns>
        public int Hash(string input)
        {
            int primeNum = 97;

            int hash = 0;

            for (int i = 0; i < input.Length; i++)
            {
                hash += primeNum + input[i] + i;
            }

            return hash % Collection.Length;
        }
        

    }
}
