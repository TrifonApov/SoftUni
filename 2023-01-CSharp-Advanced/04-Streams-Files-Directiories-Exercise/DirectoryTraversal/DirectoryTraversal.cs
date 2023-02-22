using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder report = new StringBuilder();
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);

            SortedDictionary<string, Dictionary<string, double>> exensions = new();
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                if (!exensions.ContainsKey(fileInfo.Extension))
                {
                    exensions.Add(
                        fileInfo.Extension,
                        new Dictionary<string, double> { { fileInfo.Name, (double)fileInfo.Length / 1024 } });
                }
                else
                {
                    exensions[fileInfo.Extension].Add(fileInfo.Name, (double)fileInfo.Length / 1024);
                }
            }

            foreach (var extention in exensions.OrderByDescending(e=>e.Value.Count))
            {
                report.AppendLine(extention.Key);
                foreach (var file in extention.Value.OrderBy(f=>f.Value))
                {
                    report.AppendLine($"--{file.Key} - {file.Value}kb");
                }
            }

            return report.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+reportFileName;
            File.WriteAllText(path, textContent);
        }
    }
}
