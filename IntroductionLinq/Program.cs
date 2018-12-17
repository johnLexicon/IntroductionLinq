using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;

namespace IntroductionLinq
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = null;

            OperatingSystem os = Environment.OSVersion;
            string platform = os.Platform.ToString();

            if (platform.Equals("Unix"))
            {
                path = "/Users/johnlundgren";
            }
            else if(platform.Equals("Win32NT"))
            {
                path = @"C:\windows";
            }
            else
            {
                Console.WriteLine("Not known platform.");
                return;
            }

            //ShowLargeFiles(path);

            var rep = new Repository();

            //List<Employee> developers = rep.RetrieveDevelopers();
            //IterateWithIEnumerator(developers.GetEnumerator());

            //Employee[] sales = rep.RetrieveSalesPeople();
            //IterateWithIEnumerator(sales.GetEnumerator());

            //string strDouble = "2.45";
            //Console.WriteLine(strDouble.ToDouble());

            //foreach(var dev in rep.DevelopersThatStartWithG())
            //{
            //    Console.WriteLine(dev.Name);
            //}

            //foreach (var salesPerson in rep.SalesPeopleThatStartWithK())
            //{
            //    Console.WriteLine(salesPerson.Name);
            //}

            //foreach (var employee in rep.EmployeesThatStartWithP())
            //{
            //    Console.WriteLine(employee.Name);
            //}

            //Console.WriteLine(DelegateDefinitions.AddValues(8, 9));
            //Console.WriteLine(DelegateDefinitions.CalculateArea(6));

            //DelegateDefinitions.WriteArea(5);

            //var movies = rep.RetrieveMovies();

            //var query = movies.Filter<Movie>(m => m.Year > 2000);
            //var query = movies.Where<Movie>(m => m.Year > 2000);

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            //The Take() method does that it does not create an infinite loop in the Random method.
            //var values = MyLinq.Random().Where(v => v > 0.5).Take(5);

            //foreach (var value in values)
            //{
            //    Console.WriteLine(value);
            //}

            var carRep = new Cars.CarRepository();
            var cars = carRep.Retrieve();
        }

        private static void IterateWithIEnumerator(IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
            {
                System.Console.WriteLine(enumerator.Current);
            }
        }

        private static void ShowLargeFiles(string path)
        {
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine(new String('*', 30));
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                                .OrderByDescending(f => f.Length)
                                .Take(5);

            foreach (var fileInfo in query)
            {
                Console.WriteLine($"{fileInfo.Name,-20} : {fileInfo.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] filesInfo = directoryInfo.GetFiles();

            Array.Sort(filesInfo, new FileInfoComparer());

            for(int i = 0; i < 5; i++)
            {
                var fileInfo = filesInfo[i];
                Console.WriteLine($"{fileInfo.Name, -20} : {fileInfo.Length, 10:N0}");
            }
        }
    }

    /// <summary>
    /// Class needed for comparing FileInfo objects by its size. The class has to Implement IComparer.
    /// </summary>
    class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
