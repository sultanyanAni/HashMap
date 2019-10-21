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
        public int NumberOfPairs => Collection.Select(x => x.Count).ToList().Count;

        public HashMap()
        {
            Collection = new LinkedList<Pair<TKey, TValue>>[10];
        }
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

        public void Add(TKey key, TValue value)
        {
            Add(new Pair<TKey, TValue>(key, value));
        }

        public void Add(Pair<TKey, TValue> pair)
        {
            int index = Hash(pair.Key.ToString());
            if (Collection[index] == null)
            {
                Collection[index] = new LinkedList<Pair<TKey, TValue>>();
                Collection[index].AddLast(pair);
            }
            else
            {
                bool contains = false;
                foreach (var item in Collection[index])
                {
                    if (item.Key.Equals(pair.Key))
                    {
                        contains = true;
                    }
                }

                if (contains)
                {
                    throw new Exception("");
                }
                else
                {
                    Collection[index].AddLast(pair);
                }

            }
        }

        //bool Remove(TKey key, TValue value)
        //{
        //    int index = Hash(key.ToString());

            
           
        //}

    }
}
