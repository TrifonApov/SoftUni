namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            FileInfo[] infos = directory.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo info in infos)
            {
                sum+= info.Length;
            }
            File.WriteAllText(outputFilePath, (sum / 1024).ToString());
        }
    }
}
