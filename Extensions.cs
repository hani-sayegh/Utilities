using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions
{
    static class Utilities
    {
        //Can not give till default till run time
        public static T[] SubArray<T>(this T[] source, int startIndex, int length = -1)
        {
            if (length == -1)
                length = source.Length - startIndex;

            //Interesting how substring allows having 0, but it seems have this check can actually
            //help reveal bugs if you accidently pass in 0 if for example you pass sub array to
            //method but you still want the index to be relative to the original!
            if (length < 0) throw new IndexOutOfRangeException("Start index " + startIndex + " for array of length " + source.Length);

            var destination = new T[length];
            Array.Copy(source, startIndex, destination, 0, length);
            return destination;
        }

        public static T[] Concat<T>(this T[] x, T[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            int oldLen = x.Length;
            Array.Resize(ref x, x.Length + y.Length);
            Array.Copy(y, 0, x, oldLen, y.Length);
            return x;
        }

        public static int RFactorial(this int n)
        {
            if (n < 0) throw new ArgumentException("interger must be >= 0");

            if (n == 1 || n == 0)
                return 1;
            return n * RFactorial(n - 1);
        }

        public static T Back<T>(this List<T> source)
        {
            return source[source.Count - 1];
        }

        // public static bool OR(this int n, Func<int, bool> f, params int [] list)
        // {

        // }


        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            var rightSubArray = Array.Empty<T>();
            var leftSubArray = source.SubArray(0, index);

            if (source.Length != index + 1)
                rightSubArray = source.SubArray(index + 1);

            return leftSubArray.Concat(rightSubArray);
        }

        public static void Populate<T>(this T[] source, T value, int startIndex = 0, int endIndex = -1)
        {
            if (endIndex == -1) //But if user actually enters -1 we want to stop that!!!
                endIndex = source.Length - 1;

            if (startIndex < 0 || startIndex >= source.Length || endIndex >= source.Length || startIndex >= endIndex)
                throw new IndexOutOfRangeException("Start index " + startIndex + " for array of length " + source.Length);

            for (int i = startIndex; i <= endIndex; i++)
            {
                source[i] = value;
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public static void Sort<T>(this List<T> list, int index, int count)
        {
            list.Sort(index, count, Comparer<T>.Default);
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
        //Create or function that takes in variables and condition
    }
}