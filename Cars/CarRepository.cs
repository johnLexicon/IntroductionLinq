using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Cars
{
    public class CarRepository
    {
        private List<Car> cars = null;
        private string csvFilePath = "fuel.csv";

        public IList<Car> Retrieve()
        {
            if(cars != null)
            {
                return cars;
            }

            IEnumerable<Car> rows = File.ReadAllLines(csvFilePath).Skip(1).Select(Car.ParseFromCsv);

            cars = rows.ToList();

            return cars;
        }
    }
}
