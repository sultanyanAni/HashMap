using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Numerics;

namespace HashMapV2
{
    public class HashMap<TKey, TValue>
    {
        LinkedList<Pair<TKey, TValue>>[] Collection;
        public int Count => Collection.Length;
        //public int NumberOfPairs => Collection.Where(x => x != null).Select(x => x.Count).ToList().Count; -> works but takes too long. used an int instead.

        public int NumberOfPairs { get; private set; }

        public TValue this[TKey key]
        {
            get
            {
               if(GetPair(key) == null)
                {
                    throw new Exception("key does not exist");
                }

                return GetPair(key).Value;
            }

            set
            {
                
                if (GetPair(key) == null)
                {
                    Add(key, value);
                }
                else
                {
                    GetPair(key).Value = value;
                }
             
            }
        }
            
        public HashMap()
        {
            Collection = new LinkedList<Pair<TKey, TValue>>[10];
            NumberOfPairs = 0;
        }

        /// <summary>
        /// takes in a string and returns the hash value 
        /// </summary>
        /// <param name="input">string to hash</param>
        /// <returns>hash value</returns>
        public int Hash(string input, int capacity)
        {
            int primeNum = 97;

            int hash = 0;

            for (int i = 0; i < input.Length; i++)
            {
                hash += primeNum + input[i] + i;
            }

            return hash % capacity;
        }

        public void Add(TKey key, TValue value)
        {
            Add(new Pair<TKey, TValue>(key, value));
        }

        public void Add(Pair<TKey, TValue> pair)
        {
            int index = Hash(pair.Key.ToString(), Count);
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

            NumberOfPairs++;
            if (NumberOfPairs > Collection.Length)
            {
                ReHash();
            }
        }


        public bool Remove(TKey key)
        {
            int index = Hash(key.ToString(), Count);

            foreach (var item in Collection[index])
            {
                if (item.Key.Equals(key))
                {
                    Collection[index].Remove(item);
                    NumberOfPairs--;
                    return true;
                }
            }

            return false;
        }


        public void ReHash()
        {
            LinkedList<Pair<TKey, TValue>>[] temp = new LinkedList<Pair<TKey, TValue>>[Collection.Length * 2];

            //for (int i = 0; i < Collection.Length; i++)
            //{
            //    foreach (var item in Collection[i])
            //    {
            //        int index = Hash(item.Key.ToString(), temp.Length);

            //    }
            //}


            foreach (var list in Collection)
            {
                if (list != null)
                {
                    foreach (var kvp in list)
                    {
                        if (kvp != null)
                        {
                            int newbucket = Hash(kvp.Key.ToString(), temp.Length);

                            if (temp[newbucket] == null)
                            {
                                temp[newbucket] = new LinkedList<Pair<TKey, TValue>>();
                            }

                            temp[newbucket].AddLast(kvp);

                        }
                    }
                }
            }

            Collection = temp;


        }

        Pair<TKey,TValue> GetPair(TKey key)
        {
            int index = Hash(key.ToString(), Count);

        
                foreach(var item in Collection[index])
                {
                    if(item.Key.Equals(key))
                    {
                        return item;
                    }
                }

            return null;

        }
    }
}
