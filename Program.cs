using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomExtensions;

namespace personalLib
{
    class Program
    {
        // public static void NextPermutation<T>(ref)
        // {

        // }

        static List<char[]> RPrintAllPermutations(char[] input)
        {
            var permutations = new List<char[]>();

            if (input.Length == 1)
            {
                permutations.Add(input);
                return permutations;
            }

            for (int i = 0; i != input.Length; ++i)
            {
                var rt = RPrintAllPermutations(input.RemoveAt(i));
                foreach (var val in rt)
                {
                    permutations.Add(input.SubArray(i, 1).Concat(val));
                }
            }

            Debug.Assert(permutations.Count == input.Length.RFactorial());
            return permutations;
        }

        static void Main(string[] args)
        {
            var haha = "Frewfre";
            var toto = haha.Substring(haha.Length);
            //What we know about substring, you can pass 0 for length, 
            //if start index is length of string and you have 0 that is fine

            if (args.Length != 0)
            {
                System.Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().Location);

                RPrintAllPermutations(args[0].ToCharArray()).ForEach(System.Console.WriteLine);
                return;
            }
            else
            {
                System.Console.WriteLine("Yippiii  " + System.Reflection.Assembly.GetEntryAssembly().Location);

                var tmp = RPrintAllPermutations("1234".ToCharArray());
                tmp.ForEach(Console.WriteLine);
                Console.WriteLine("Hello World!");
            }

        }
    }
}
