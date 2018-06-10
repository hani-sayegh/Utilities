using System;
using System.Collections.Generic;
using CustomExtensions;

namespace personalLib
{
    class Program
    {
        //Example input: 123
        //Example Output after each call to function:
        // 123
        // 321
        // 231
        // 132
        // 312
        // 213

        // public static void NextPermutation<T>(ref)
        // {

        // }


        static List<char[]> RPrintAllPermutations(char[] a)
        {
            var tmp = new List<char[]>();

            if (a.Length == 1)
            {
                tmp.Add(a);
                return tmp;
            }


            for (int i = 0; i != a.Length; ++i)
            {
                var rt = RPrintAllPermutations(a.SubArray(i + 1));
                foreach (var val in rt)
                {
                    tmp.Add(a.SubArray(0, 1).Concat(val));
                }
            }
            return tmp;
        }

        static void Main(string[] args)
        {
            var haha = "Frewfre";
            var toto = haha.Substring(0,0);
            // var tmp = RPrintAllPermutations("12".ToCharArray());
            // tmp.ForEach(Console.WriteLine);
            Console.WriteLine("Hello World!");
        }
    }
}
