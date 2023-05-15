// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Polymorphism using Interface");

// 1. Rectangle

IShape shape = new Reactangle();
Dimensions dimensions1 = new Dimensions() {Width =  100, Height = 200};
AreaGenerator areaGenerator = new AreaGenerator();
Console.WriteLine($"Area of REctangle = {areaGenerator.GetArea(shape, dimensions1)}");

// 2. CIrcle

shape = new Circle();
Console.WriteLine($"Area of Circle = {areaGenerator.GetArea(shape, dimensions1)}");

// 3. Square
shape = new Square();
Console.WriteLine($"Area of Square = {areaGenerator.GetArea(shape, dimensions1)}");
Console.ReadLine();




/// <summary>
/// Gateway class to get area of the Shape
/// Polymorphic behavior to the GetArea() method based on type of IShape
/// </summary>
public class AreaGenerator
{
    /// <summary>
    /// Substitution of ISHape at runtime by classes implmenting IShape interface 
    /// </summary>
    /// <param name="shape"></param>
    /// <param name="dimensions"></param>
    /// <returns></returns>
    public double GetArea(IShape shape, Dimensions dimensions)
    {
        return shape.CalculateArea(dimensions.Height , dimensions.Width);
    }
}

public class Dimensions
{
    public double Height { get; set; }
    public double Width { get; set; }
}


public interface IShape
{
    double CalculateArea(double height, double width);
}


public class Reactangle : IShape
{
    double IShape.CalculateArea(double height, double width)
    {
        return height * width;
    }
}

public class Circle : IShape
{
    double IShape.CalculateArea(double height, double width)
    {
        double radius = width /  2;

        return Math.PI * radius * radius;
    }
}


public class Square : IShape
{
    double IShape.CalculateArea(double height, double width)
    {
        return height * height;
    }
}
