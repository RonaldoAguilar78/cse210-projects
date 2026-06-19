using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Build a List to hold shapes
        List<Shape> shapes = new List<Shape>();

        // 2. Create the instances
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        // 3. Iterate through the list
        foreach (Shape s in shapes)
        {
            // The compiler figures out which GetArea() to call based on the object's actual type
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}