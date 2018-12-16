using System;
namespace IntroductionLinq
{
    public static class StringExtensions
    {
        public static double ToDouble(this string strDouble)
        {
            return double.Parse(strDouble);
        }
    }
}
