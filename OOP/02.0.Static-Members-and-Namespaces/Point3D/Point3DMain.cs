namespace Point3D
{
    using System;

    class Point3DMain
    {
        static void Main()
        {
            var point = new Point3D();
            
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());
            var z = double.Parse(Console.ReadLine());

            var point1 = new Point3D(x,y,z);
            
            Console.WriteLine(point.ToString());
            Console.WriteLine(point1.ToString());

            Console.WriteLine(string.Join("; ",Point3D.StartPoint));
        }
    }
}
