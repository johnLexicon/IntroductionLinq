using System;
namespace IntroductionLinq
{
    public static class DelegateDefinitions
    {
        /// <summary>
        /// Func definition that takes an int as parameter and returns an int
        /// </summary>
        static readonly Func<int, int> area = x => x * x;

        /// <summary>
        /// Func definition that takes two int parameters and returns an int
        /// </summary>
        static readonly Func<int, int, int> add = (x, y) => x + y;

        static readonly Action<int> writeInteger = i => Console.WriteLine(i);

        internal static int CalculateArea(int side)
        {
            return area(side);
        }

        internal static int AddValues(int x, int y)
        {
            return add(x, y);
        }

        internal static void WriteArea(int side)
        {
            writeInteger(area(side));
        }
    }
}
