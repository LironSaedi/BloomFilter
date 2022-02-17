using System;

namespace BloomFilter
{
    class Program
    {
        static int AddOne(int n)
        {
            return n + 1;
        }

        static void Main(string[] args)
        {
            Func<string, int> hash1 = (string s) => s.GetHashCode();
            Func<string, int> hash2 = (string s) => (s + "adsafs").GetHashCode();

            Func<int, int> add = AddOne;
            int y = add(23);

            Console.WriteLine("Hello World!");
        }
    }
}
