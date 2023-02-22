using System.Collections.Generic;
using System.Linq;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> bytes = new();
            using (StreamReader sr = new StreamReader(bytesFilePath))
            {
                string line = sr.ReadLine();
                while (line!=null)
                {
                    bytes.Add(byte.Parse(line));
                    line = sr.ReadLine();
                }
            }

            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            List<string>output = new();
            foreach (byte b in fileBytes)
            {
                if (bytes.Contains(b))
                {
                    output.Add(b + "\n");
                }
            }
            
            File.WriteAllLines(outputPath,output);
        }
    }
}
