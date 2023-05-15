// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;

Console.WriteLine("DEMO Methods");

string name = "James Andrew Bond";

Console.WriteLine($"Uper case of {name} = {ChangeCase(name, 'u')}");
Console.WriteLine(  );
Console.WriteLine( $"Lower case of {name} = {ChangeCase(name, 'l')}");
Console.WriteLine();
Console.WriteLine($"If name is 'null' {ChangeCase(null, 'l')}");
Console.WriteLine(  );
Console.WriteLine($"If case value is blankspace {ChangeCase(name, ' ')}");


// call the method
PrintMessage();
Console.WriteLine();
PrintString(name);

Console.ReadLine();

/*In Program.cs all methods will be part of Program class and all methods MUST be static*/

// Method w/o input and output parameters

static void PrintMessage()
{
    Console.WriteLine("I am void method");
}

// A method with input parameter but not output
// 

static void PrintString(string n)
{
    Console.WriteLine($"Entered String = {n}");
}

// Method with inut and output parameter

static string ChangeCase(string str, char c)
{
    // Always (in most cases) validate the received parameters
    // using if condition
    // check if the str is not null or empty
    if (string.IsNullOrEmpty(str))
        return "Vale cannot be empty or null";
    if (c == ' ')
        return "Choice for the case is must";



    string output = string.Empty;
    switch (c)
    {
        case 'l':
            output = str.ToLower();
            break;
        case 'u':
            output = str.ToUpper();
            break;
        default:
            output = str;
            break;
    }
    return output;
}