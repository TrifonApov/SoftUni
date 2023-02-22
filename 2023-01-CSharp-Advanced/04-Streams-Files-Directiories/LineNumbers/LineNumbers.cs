namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (streamReader)
            {
                using (writer)
                {
                    string line = streamReader.ReadLine();
                    int lineNumber = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{lineNumber}. {line}");
                        lineNumber++;
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
