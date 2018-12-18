using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionLinq
{
    public static class MyLinq
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An object that implements an IEnumerable interface that has a GetEnumerator method that returns an Enumerator (An enumerator can be used to iterate in a foreach loop)</returns>
        public static IEnumerable<double> Random()
        {
            var rnd = new Random();
            while (true)
            {
                yield return rnd.NextDouble();
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach(var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
