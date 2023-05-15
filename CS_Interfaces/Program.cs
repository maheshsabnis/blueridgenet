// See https://aka.ms/new-console-template for more information

using CS_Interfaces.Logic;
Console.WriteLine("DEMO Interfaes");
// 1. Accessing methods using the class instace
Mathematics m1 = new Mathematics();
Console.WriteLine($"Add = {m1.Add(10,20)}");
Console.WriteLine($"Substract = {m1.Subtract(40,30)}");

// 2. Accessing methods using interace reference

IMath m2 = new Mathematics();
Console.WriteLine($"Add = {m2.Add(10, 20)}");
Console.WriteLine($"Substract = {m2.Subtract(40, 30)}");

// 3. Accessing methods from explicit implementation from Class

IMath m3 = new MathematicsExplicit();
Console.WriteLine($"Add = {m3.Add(100, 20)}");
Console.WriteLine($"Substract = {m3.Subtract(400, 30)}");

IMathNew m4 = new MathematicsExplicit();

Console.WriteLine(  $"Add Square = {m4.Add(10,20)}");
Console.WriteLine($"Substract Square = {m4.Subtract(80, 60)}");

Console.ReadLine();
