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
            //Tom should FIXME
            return 1000;
        }
    }
}
