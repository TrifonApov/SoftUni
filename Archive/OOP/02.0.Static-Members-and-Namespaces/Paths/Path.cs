namespace Paths
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Point3D;
    using CalculateDistance;

    public class Path
    {
        private List<Point3D> path3D;

        public Path()
        {
            this.Path3D = new List<Point3D>();
        }

        public List<Point3D> Path3D
        {
            get
            {
                return this.path3D;
            }
            set { this.path3D = value; }
        }

        public Point3D this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.path3D[index];
            }
        }

        public void SaveAsFile(string name)
        {
            Storage.Save(this.ToString(), name);
        }

        public void AddPoint(Point3D point)
        {
            this.path3D.Add(point);
        }

        public void AddRange(Point3D[] points)
        {
            this.path3D.AddRange(points);
        }

        public void DeletePoint(int index)
        {
            this.ValidateIndex(index);
            this.path3D.RemoveAt(index);
        }

        public void DeleteRange(int startIndex, int count)
        {
            this.ValidateIndex(startIndex);
            this.ValidateCount(startIndex, count);
            this.path3D.RemoveRange(startIndex, count);
        }

        public double CalculatePathDistance()
        {
            double distance = 0;
            for (int index = 1; index < this.path3D.Count; index++)
            {
                distance += CalculteDistance.CalculateDistance(this.path3D[index], this.path3D[index - 1]);
            }
            return distance;
        }

        public static Path LoadFromFile(string filePath)
        {
            return Storage.Load(filePath);
        }

        private void ValidateCount(int startIndex, int count)
        {
            if (count > this.path3D.Count - startIndex)
            {
                throw new ArgumentOutOfRangeException("count", "There no "+count+" points to delete after starting index");
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.path3D.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index is out of range");
            }
        }

        public override string ToString()
        {
            StringBuilder pathInfo = new StringBuilder();

            for (int index = 0; index < this.path3D.Count; index++)
            {
                var point3D = this.path3D[index];
                pathInfo.AppendFormat("Point {0} ({1}, {2}, {3})\n", 
                    index,
                    point3D.PointX,
                    point3D.PointY,
                    point3D.PointZ);
            }
            return pathInfo.ToString();
        }
    }
}