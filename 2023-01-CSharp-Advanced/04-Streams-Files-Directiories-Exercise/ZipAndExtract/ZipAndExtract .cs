using System.IO.Compression;

namespace ZipAndExtract
{
    using System;
    using System.IO;
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))   
            {
                File.Delete(zipArchiveFilePath);
            }
            using ZipArchive zip = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Update);
            {
                string filename = Path.GetFileName(inputFilePath);
                zip.CreateEntryFromFile(inputFilePath, "extracted.png");
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive zip = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Update))
            {
                zip.ExtractToDirectory(Path.GetDirectoryName(zipArchiveFilePath));
            }
        }
    }
}
