using System;

namespace ClassBoxData;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return length; }
        private set
        {
            ValidateSize("Length",value);
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            ValidateSize("Width",value);
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            ValidateSize("Height",value);
            height = value;
        }
    }

    //Calculate and return the surface area of the Box.
    public double SurfaceArea()
    {
        // 2lw + 2lh + 2wh
        return 2 * length * width + 2 * length * height + 2 * width * height;
    }

    //Calculate and return the lateral surface area of the Box.
    public double LateralSurfaceArea()
    {
        return 2 * length * height + 2 * width * height;
    }

    //Calculate and return the volume of the Box.
    public double Volume()
    {
        return length * height * width;
    }

    private void ValidateSize(string propertyName, double value)
    {
        if (value<=0)
        {
            throw new ArgumentException($"{propertyName} cannot be zero or negative.");
        }
    }
}