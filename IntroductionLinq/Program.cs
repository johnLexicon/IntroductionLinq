using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
