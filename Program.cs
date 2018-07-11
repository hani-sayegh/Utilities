using System.IO;
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
            //Should be taken to seperate file.
            ///
            string fullFilePath = @"C:\Users\battlepants\Desktop\sdf.txt";
            var tmp = File.ReadAllLines(fullFilePath);
            var lines = new List<string>();
            foreach (var line in tmp)
            {
                var lineLength = line.Length;
                var lineLengthLimit = 80;
                var lineIdx = System.Math.Min(lineLengthLimit, lineLength);
                var startIdx = 0;
                while (lineIdx < lineLength)
                {   
                    while (!System.Char.IsWhiteSpace(line[lineIdx]))
                    {
                        --lineIdx;
                        if (lineIdx == -1)
                            goto Ju;

                    }
                    lines.Add(line.Substring(startIdx
                    , lineIdx - startIdx));
                    startIdx = lineIdx + 1;
                    lineIdx += lineLengthLimit;
                }
            Ju:
                lines.Add(line.Substring(startIdx));
            }
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(fullFilePath), "BiggApl"),
            lines);
            return;
            ///
            var toto = new int[] { 1, 2, 3 };

            var subseqs = Enumerable.Range(0, 3).SelectMany(x => toto.Combinations(x));

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
