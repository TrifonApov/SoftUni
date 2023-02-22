using System.Text;

namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int countLines = 1;
            StringBuilder stringBuilder = new StringBuilder();
            string[] lines = File.ReadAllLines(inputFilePath);
            foreach (string line in lines)
            {
                int countLetters = 0;
                int countSymbols = 0;
                foreach (char character in line)
                {
                    if ((character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z'))
                    {
                        countLetters++;
                    }
                    else if (character != ' ')
                    {
                        countSymbols++;
                    }
                }
                stringBuilder.AppendLine($"Line {countLines++}: -I was quick to judge him, but it wasn't his fault. ({countLetters})({countSymbols})");
            }
            File.WriteAllText(outputFilePath, stringBuilder.ToString());
        }
    }
}
