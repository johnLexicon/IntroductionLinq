using System;
namespace IntroductionLinq
{
    public class Employee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id, -5} : {Name}";
        }

    }
}
