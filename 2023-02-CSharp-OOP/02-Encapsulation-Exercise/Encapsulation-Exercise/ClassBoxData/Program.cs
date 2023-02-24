using System;

namespace ClassBoxData;

public class Program
{
    static void Main(string[] args)
    {
        double length = Double.Parse(Console.ReadLine());
        double width = Double.Parse(Console.ReadLine());
        double height = Double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }

    }
}