using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle("Red", 5.0);
        Console.WriteLine("Circle:");
        circle.DisplayColor();
        Console.WriteLine($"Area: {circle.GetArea():F2}\n");
        Rectangle rectangle = new Rectangle("Blue", 4.0, 6.0);
        Console.WriteLine("Rectangle:");
        rectangle.DisplayColor();
        Console.WriteLine($"Area: {rectangle.GetArea():F2}\n");
        // Showing creativity: Dynamically build a list of shapes and compute total area polymorphically
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle("Green", 3.0));
        shapes.Add(new Rectangle("Yellow", 2.0, 8.0));
        shapes.Add(circle);  // Reuse existing object
        double totalArea = 0.0;
        foreach (Shape shape in shapes)
        {
            shape.DisplayColor();
            totalArea += shape.GetArea();
        }
        Console.WriteLine($"\nTotal Area of All Shapes: {totalArea:F2}");
    }
}
