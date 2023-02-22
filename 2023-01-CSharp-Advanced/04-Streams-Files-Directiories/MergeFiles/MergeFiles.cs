using System.Collections.Generic;

namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstReader = new StreamReader(firstInputFilePath);
            StreamReader secondReader = new StreamReader(secondInputFilePath);
            List<string> firstInputLine = new List<string>();
            List<string> secondInputLine = new List<string>();
            
            using (firstReader)
            {
                string line = firstReader.ReadLine();
                while (line != null)
                {
                    firstInputLine.Add(line);
                    line = firstReader.ReadLine();
                }
            }
            using (secondReader)
            {
                string line = secondReader.ReadLine();
                while (line != null)
                {
                    secondInputLine.Add(line);
                    line = secondReader.ReadLine();
                }
            }
            
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                int max = firstInputLine.Count > secondInputLine.Count ? firstInputLine.Count : secondInputLine.Count;
                for (int i = 0; i < max; i++)
                {
                    if (i < firstInputLine.Count)
                    {
                        writer.WriteLine(firstInputLine[i]);
                    }

                    if (i < secondInputLine.Count)
                    {
                        writer.WriteLine(secondInputLine[i]);
                    }
                }
            }
        }
    }
}
