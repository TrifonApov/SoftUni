namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string output = string.Empty;

            StreamReader streamReader = new StreamReader(inputFilePath);
            string line = streamReader.ReadLine();
            int countLines = 0;
            while (line != null)
            {
                if (countLines % 2 == 0)
                {

                    char[] chars = new char[] { '-', ',', '.', '!', '?' };
                    line = chars.Aggregate(line, (c1, c2) => c1.Replace(c2, '@'));
                    string[] reversed = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

                    output += $"{string.Join(" ",reversed)}{Environment.NewLine}";

                }
                countLines++;
                line = streamReader.ReadLine();
            }

            return output;
        }
    }
}
