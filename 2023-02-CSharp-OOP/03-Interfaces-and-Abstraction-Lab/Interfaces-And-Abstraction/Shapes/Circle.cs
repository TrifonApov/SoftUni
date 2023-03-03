using System;

namespace Shapes;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        Radius = radius;
    }

    public int Radius
    {
        get => radius;
        private set
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(Radius)} can't be negative");

            radius = value;
        }
    }

    public void Draw()
    {
        Console.WriteLine($"{new string(' ', radius)}{new string('*', radius * 2 + 1)}{new string(' ', radius)}");
        int innerCount = radius * 2 + 1;
        int outerCount = radius - 2;
        for (int i = radius - 1; i > 0; i--)
        {
            Console.WriteLine($"{new string(' ', outerCount)}**{new string(' ', innerCount)}**{new string(' ', outerCount)}");
            innerCount += 2;
            outerCount -= 2;
            if (outerCount < 0 ) outerCount = 0;
        }

        Console.WriteLine($"*{new string(' ', innerCount)}*");

        
        for (int i = 0; i < radius-1; i++)
        {
            innerCount -= 2;
            Console.WriteLine($"{new string(' ', outerCount)}**{new string(' ', innerCount)}**{new string(' ', outerCount)}");
            if (outerCount == 0) outerCount = 1;
            else outerCount += 2;
        }

        Console.WriteLine($"{new string(' ', radius)}{new string('*', radius * 2 + 1)}{new string(' ', radius)}");
    }
}