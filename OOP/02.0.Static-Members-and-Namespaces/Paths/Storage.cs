namespace Paths
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using Point3D;

    public static class Storage
    {
        public static void Save(string path, string name)
        {
            File.WriteAllText("../../" + name + ".txt",path);
        }

        public static Path Load(string filePath)
        {
            var file = File.ReadLines(filePath);
            var path = new Path();
            foreach (var line in file)
            {
                Regex r = new Regex("\\((-?\\d+\\.*\\d*), (-?\\d+\\.*\\d*), (-?\\d+\\.*\\d*)\\)");
                Match m = r.Match(line);
                var point = new Point3D(
                    double.Parse(m.Groups[1].Value),
                    double.Parse(m.Groups[2].Value),
                    double.Parse(m.Groups[3].Value)
                    );
                path.AddPoint(point);
            }
            return path;
        }
    }
}