using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomExtensions;
using System.Linq;

namespace personalLib
{
    class Program
    {
        public static bool NextPermutation(List<int> number)
        {
            var originalNumber = new List<int>(number);
            //Array that contains next largest integer for integer i in array
            //
            var nextLargestInteger = new int[10]; //Assume no zero in number
            nextLargestInteger.Populate(-1);
            for (int digitIdx = number.Count - 1; digitIdx >= 0; --digitIdx)
            {
                var currentDigit = number[digitIdx];
                var nextLargestDigit = nextLargestInteger[currentDigit];
                if (nextLargestDigit == -1)
                {
                    for (int j = currentDigit - 1; j >= 0; --j)
                    {
                        if (nextLargestInteger[j] != -1)
                            break;
                        nextLargestInteger[j] = digitIdx;
                    }
                }
                else
                {
                    number.Swap(digitIdx, nextLargestDigit);
                    number.Sort(digitIdx + 1, number.Count - (digitIdx + 1));
                    break;
                }
            }
            if (number.SequenceEqual(originalNumber))
            {
                number.Sort();
                return false;
            }

            return true;
        }

        static List<char[]> RPermutations(char[] input)
        {
            var permutations = new List<char[]>();

            //Base Case
            if (input.Length == 1)
            {
                permutations.Add(input);
                return permutations;
            }

            for (int i = 0; i != input.Length; ++i)
            {
                var subPermutations = RPermutations(input.RemoveAt(i));
                foreach (var val in subPermutations)
                {
                    permutations.Add(input.SubArray(i, 1).Concat(val));
                }
            }

            Debug.Assert(permutations.Count == input.Length.RFactorial());
            return permutations;
        }


        static void Main(string[] args)
        {
            int a = 10;
            int b = 12;

            Utilities.Swap(ref a, ref b);
            var haha = "Frewfre";
            var toto = haha.Substring(haha.Length);
            //What we know about substring, you can pass 0 for length, 
            //if start index is length of string and you have 0 that is fine

            if (args.Length != 0)
            {
                System.Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().Location);

                RPermutations(args[0].ToCharArray()).ForEach(System.Console.WriteLine);
                return;
            }
            else
            {
                System.Console.WriteLine("Yippiii  " + System.Reflection.Assembly.GetEntryAssembly().Location);

                // var tmp = RPermutations("1234".ToCharArray());
                // tmp.ForEach(Console.WriteLine);
                var number = new List<int> { 1, 2, 3 };


                while (NextPermutation(number))
                {
                    number.ForEach(System.Console.Write);
                    System.Console.WriteLine();

                }

            }
        }
    }
}
