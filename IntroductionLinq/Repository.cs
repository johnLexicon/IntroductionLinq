using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionLinq
{
    public class Repository
    {

        public IEnumerable<Movie> RetrieveMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Title = "Rambo 10",
                    Rating = 9.1,
                    Year = 2020
                },
                new Movie
                {
                    Title = "Creed 4",
                    Rating = 6.2,
                    Year = 2021
                },
                new Movie
                {
                    Title = "Casablanca",
                    Rating = 8.4,
                    Year = 1942
                }
            };
        }

        public List<Employee> RetrieveDevelopers()
        {

            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Gosia"

                }
            };
        }

        public Employee[] RetrieveSalesPeople()
        {
            return new Employee[]
            {
                new Employee
                {
                    Id = 3,
                    Name = "Patricya"
                },
                new Employee
                {
                    Id = 4,
                    Name = "Krolik"
                }
            };
        }

        public IEnumerable<Employee> DevelopersThatStartWithG()
        {
            var developers = RetrieveDevelopers();
            var query = developers.Where(StartsWithG);
            return query;
        }

        public IEnumerable<Employee> SalesPeopleThatStartWithK()
        {
            var salesPeople = RetrieveSalesPeople();
            var query = salesPeople.Where(delegate (Employee e)
            {
                return e.Name.ToLower().StartsWith("k", StringComparison.CurrentCulture);
            });
            return query;
        }

        public IEnumerable<Employee> EmployeesThatStartWithP()
        {
            var employees = RetrieveDevelopers();
            employees.AddRange(RetrieveSalesPeople());

            var query = employees.Where(e => e.Name.ToLower().StartsWith("p", StringComparison.CurrentCulture));
            return query;
        }

        private bool StartsWithG(Employee employee)
        {
            return employee.Name.ToLower().StartsWith("g", StringComparison.CurrentCulture);
        }
    }
}
