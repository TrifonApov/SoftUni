namespace CalculateDistance
{
    using System;
    using Point3D;

    public class CalculateDistnanceMain
    {
        public static void Main()
        {
            var a = new Point3D();
            var b = new Point3D(1,1,1);
            Console.WriteLine(CalculteDistance.CalculateDistance(a,b));
        } 
    }
}