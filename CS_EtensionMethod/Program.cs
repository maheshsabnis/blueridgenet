// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Extension Methods");

Mathematics m = new Mathematics();

Console.WriteLine($"Add = {m.Add(100,200)}");

Console.WriteLine($"Multipley = {m.Mutiply(30,50)}");
// INterface Reference created using Mathematics class
IOperations op1 = new Mathematics();

Console.WriteLine($"Substract = {op1.Substract(10,5)}");

Console.WriteLine($"Power using an instance of Mathematics class = {m.Power(2,3)}");
Console.WriteLine($"Power using an IOperations  reference created using Mathematics class = {op1.Power(2, 5)}");

MathematicsNew m1 = new MathematicsNew();

Console.WriteLine($"Power using MathematicsNew instace = {m1.Power(4,9)}");


string Name = "James Andrew Bond";

Console.WriteLine($"Reverse of {Name} is = {Name.ReverseString()}");


Console.ReadLine();



public interface IOperations
{
    int Substract(int x, int y);
}

public sealed class Mathematics : IOperations
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    int IOperations.Substract(int x, int y)
    {
        return (x - y) + y;
    }
}



public sealed class MathematicsNew : IOperations
{
     

    int IOperations.Substract(int x, int y)
    {
        return (x - y) + y;
    }
}


public static class MyExtension
{
    /// <summary>
    /// AN Extension method for Mathematis class
    /// </summary>
    /// <param name="m"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Mutiply(this Mathematics m, int a, int b)
    { 
        return a * b + a * a + b * b + a * 100 * b;
    }

    /// <summary>
    /// Extension method for IOperations interface
    /// ALl classes implementing IOperaions can access Power()
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double Power(this IOperations obj, double a,double b) 
    { 
      return Math.Pow(a,b);
    }


    public static string ReverseString(this string str)
    {
        string reverse = string.Empty;
        for (int i = str.Length - 1; i >= 0; i--)
        { 
          reverse += str[i];
        }
        return reverse;
    }
}
