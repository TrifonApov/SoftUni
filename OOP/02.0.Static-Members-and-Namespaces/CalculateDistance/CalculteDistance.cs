namespace CalculateDistance
{
    using System;
    using System.Reflection;
    using Point3D;

    public class CalculteDistance
    {
        /// <summary>
        /// Take two point and calculate the distance between them
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static double CalculateDistance(Point3D first, Point3D second)
        {

            double distance = Math.Pow(second.PointX - first.PointX, 2);
            distance += Math.Pow(second.PointY - first.PointY, 2);
            distance += Math.Pow(second.PointZ - first.PointZ, 2);
            distance = Math.Sqrt(distance);

            return distance;
        }
    }
}
