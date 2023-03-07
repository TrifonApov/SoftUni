using System;
using System.Collections.Generic;

namespace Shapes;

public class StartUp
{
    static void Main(string[] args)
    {
        Shape rectangle = new Rectangle(2, 3);
        Shape circle = new Circle(23);
        List<Shape> shapes = new List<Shape>();
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());
        }

        
    }
}