using System.Text.RegularExpressions;

namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader wordsReader = new StreamReader(wordsFilePath);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            using (wordsReader)
            {
                string[] words = wordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    wordCounts.Add(word.ToLower(), 0);
                }
            }

            StreamReader textReader = new StreamReader(textFilePath);

            using (textReader)
            {
                string regexPattern = @"\w+";
                Regex regex = new Regex(regexPattern);
                MatchCollection matches = regex.Matches(textReader.ReadToEnd());



                foreach (var match in matches)
                {
                    var word = match.ToString().ToLower();
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                }
            }
            
            StreamWriter textWriter = new StreamWriter(outputFilePath);
            using (textWriter)
            {
                foreach (var wordCount in wordCounts.OrderByDescending(w=>w.Value))
                {
                    textWriter.WriteLine($"{wordCount.Key} - {wordCount.Value}");
                }
            }
        }
    }
}
