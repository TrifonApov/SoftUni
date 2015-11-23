namespace Paths
{
    using System;
    using Point3D;

    class PathsMain
    {
        static void Main()
        {
            var path = new Path();

            var point = new Point3D();
            var point1 = new Point3D(1,1,1);
            var point2 = new Point3D(2,2,2);
            var point3 = new Point3D(-1,-1,-1);
            var point4 = new Point3D(0.23,-23.23,12.3);
            var point5 = new Point3D(5,5,5);
            var point6 = new Point3D(6,6,6);
            var point7 = new Point3D(7,7,7);

            path.AddPoint(point);
            path.AddPoint(point1);
            path.AddPoint(point2);

            var points = new[] {point3, point4, point5, point6, point7};
            path.AddRange(points);
            path.SaveAsFile("PathBeforeDeletePoints");

            path.DeletePoint(1);
            path.DeleteRange(0,2);
            path.SaveAsFile("PathAfterDeletePoints");
            
            var pathLoadFromFile = Path.LoadFromFile("../../PathAfterDeletePoints.txt");

            Console.WriteLine(pathLoadFromFile.ToString());
            Console.WriteLine(pathLoadFromFile.CalculatePathDistance());
        }
    }
}
