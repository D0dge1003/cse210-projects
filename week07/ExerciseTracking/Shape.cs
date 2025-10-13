using System;
using System.Collections.Generic;
public class Shape
{
    protected string Color { get; set; }
    public Shape(string color)
    {
        Color = color;
    }
    public virtual double GetArea()
    {
        return 0.0;
    }
    public void DisplayColor()
    {
        Console.WriteLine($"Color: {Color}");
    }
}