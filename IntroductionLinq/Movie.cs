using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionLinq
{
    public class Movie
    {
        private int _year;

        public string Title { get; set; }
        public double Rating { get; set; }
        public int Year {
            get {
                Console.WriteLine($"Returning { _year } for movie { Title }");
                return _year;
            }
            set => _year = value; }

        public override string ToString()
        {
            return $"{ Title } : { Rating } : { Year }";
        }
    }
}
