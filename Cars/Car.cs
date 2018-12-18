using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        internal static Car ParseFromCsv(string row)
        {
            var cols = row.Split(',');

            return new Car
            {
                Year = int.Parse(cols[0]),
                Manufacturer = cols[1],
                Name = cols[2],
                Displacement = double.Parse(cols[3], CultureInfo.InvariantCulture), //Invariant culture makes it possible to parse values using a dot instead of a comma.
                Cylinders = int.Parse(cols[4]),
                City = int.Parse(cols[5]),
                Highway = int.Parse(cols[6]),
                Combined = int.Parse(cols[7])
            };
        }
    }
}
