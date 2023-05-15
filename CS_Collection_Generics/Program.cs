
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Generic");
// USing Generic List
List<int> intList = new List<int>();    
intList.Add(10);
intList.Add(20);
intList.Add(30);
intList.Add(40);

foreach (int i in intList)
{
    Console.WriteLine(i);
}

Console.ReadLine();
