using System;
using System.IO;
using RobotService.IO.Contracts;

namespace RobotService.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", false))
            {
                writer.Write(String.Empty);
            }
        }
        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt",true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}