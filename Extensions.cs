using System;

namespace CustomExtensions
{
    static class Tmp
    {
        //Can not give till default till run time
        public static T[] SubArray<T>(this T[] source, int startIndex, int length = -1)
        {
            if (length == -1)
                length = source.Length - startIndex;

            if (length <= 0) throw new IndexOutOfRangeException("Start index " + startIndex + " for array of length " + source.Length);

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

//         public static T[] Exclude<T>(this T[] source, int index)
//         {
//             source.
// source.SubArray(0, index).Concat(source.SubArray(index))
//         }
    }
}