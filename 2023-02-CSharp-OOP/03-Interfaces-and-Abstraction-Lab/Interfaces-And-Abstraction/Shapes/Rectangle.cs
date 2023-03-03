using System;

namespace Shapes;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width
    {
        get => width;
        private set
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(Width)} can't be negative.");

            width = value;
        }
    }

    public int Height
    {
        get => height;
        private set
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(Height)} can't be negative.");
            
            height = value;
        }
    }
	
    public void Draw()
    {
        Console.WriteLine(new string('*', width));
        for (int i = 1; i < height; i++)
        {
            Console.WriteLine($"*{new string(' ', width-2)}*");
        }
        Console.WriteLine(new string('*', width));
    }
}