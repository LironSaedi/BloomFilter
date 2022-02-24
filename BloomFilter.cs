using System;
using System.Collections.Generic;
using System.Text;

namespace BloomFilter
{
    class BloomFilter<T>
    {
        bool[] array;
        Func<T, int>[] hashFunctions;
        public BloomFilter(int cap, Func<T, int>[] hashFunctions)
        {
            this.array = new bool[cap];
            this.hashFunctions = hashFunctions;
        }

        public void Insert(T item)
        {
            int hashCode = Math.Abs(HashFuncOne(item));
            hashCode = hashCode % array.Length;
            array[hashCode] = true;
        }

        public bool ProbablyContains(T item)
        {
            int hashCode = Math.Abs(HashFuncOne(item));
            hashCode = hashCode % array.Length;

            if (!(array[hashCode]))
            {
                return false;
            }

            return true;
        }

        private int HashFuncOne(T item)
        {
            return item.GetHashCode();
        }

        private int HashFuncTwo(T item)
        {
            /* Silly hash
               1. Multiply each ACSII value by it's position in the string (1-based)
               2. Add results

                Ex: "Hi" -> 72 * 1 + 105 * 2 = 282
                    "iH" -> 105 * 1 + 72 * 2 = 249
            */


            /*
             
             uint prime1 = 16811891;
        uint prime2 = 16777619;
        uint prime3 = 16998109;
        
        int cap = 112;
        string hashMe = "Cat";
        
        Console.WriteLine($"Prime1: {ComputeStringHash(hashMe, prime1)}, bucket: {ComputeStringHash(hashMe, prime1) % cap}");
        Console.WriteLine($"Prime2: {ComputeStringHash(hashMe, prime2)}, bucket: {ComputeStringHash(hashMe, prime2) % cap}");
        Console.WriteLine($"Prime3: {ComputeStringHash(hashMe, prime3)}, bucket: {ComputeStringHash(hashMe, prime3) % cap}");
        
    }
    
    
    static uint ComputeStringHash(string hashMe, uint prime)
    {
        uint temp = 2166136261;
        
        for (int i = 0; i < hashMe.Length; i++)
        {
            char letter = hashMe[i];
            
            temp = (letter ^ temp) * prime;
        }
        
        return temp;
    }
             
             */

        }
    }
}
