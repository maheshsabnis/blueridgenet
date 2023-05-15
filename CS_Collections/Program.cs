// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Collection Classes");

int i = 10;
object o = i; // Boxing


Console.WriteLine($"Tyoe in o is {o.GetType()} and value in o = {o}");

int j = (int)o; //Unboxing
Console.WriteLine(  j);



ArrayList arr  =new ArrayList();
arr.Add(10);
arr.Add(20);
arr.Add(30);
arr.Add(10.3);
arr.Add(10.5);
arr.Add(10.7);
arr.Add("A");
arr.Add("B");
arr.Add('a');
arr.Add('b');

Person p = new Person();
p.Id = 101; p.Name = "ABC";
arr.Add(p);


foreach (object item in arr)
{
    Console.WriteLine($"TYpe of item = {item.GetType()} and Value of item = {Convert.ToInt32(item)}"  );
}
Console.WriteLine(  );
// Reading only integers
// 

foreach (object item in arr)
{
    if (item.GetType() == typeof(int))
    {
        Console.WriteLine(item);
    }
}

Console.WriteLine(  );

// Only Person Object

foreach (object item in arr)
{
    if (item.GetType() == typeof(Person))
    {
        // Typecast entries in colleetion to read person data 
        Console.WriteLine($"Id = {((Person)item).Id} and NAme = {((Person)item).Name} ");
    }
}

Console.ReadLine();


public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}