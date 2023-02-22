namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (streamReader)
            {
                using (writer)
                {
                    string line = streamReader.ReadLine();
                    int lineNumber = 0;
                    while (line != null)
                    {
                        if (lineNumber % 2 == 0)
                        {
                            writer.WriteLine(line);
                        }
                        lineNumber++;
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
