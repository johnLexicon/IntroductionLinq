using System;
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
            else
            {
                path = @"C:\windows";
            }

            ShowLargeFilesWithoutLinq(path);
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] filesInfo = directoryInfo.GetFiles();

            foreach (var fileInfo in filesInfo)
            {
                Console.WriteLine($"{fileInfo.Name} : {fileInfo.Length}");
            }
        }
    }
}
