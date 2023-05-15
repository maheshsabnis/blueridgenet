// See https://aka.ms/new-console-template for more information
Console.WriteLine("C# Strings");

// Define String
string strData = "The .NET 6 is greate technology";

string infomation = "The .NET 6 provides Desktop, Web, Mobile, Cloud based app Models";

// Concatinate String (Traditional Way)

string strInfo = strData + "." + infomation + ".";

Console.WriteLine(" Complete String = " + strInfo);

// C# 7.0 + use string interpolation (Recommended)

string strDataInformation = $"{strData}.{infomation}";

Console.WriteLine($"Using interpolation = {strDataInformation}");

Console.WriteLine($"{100 * 200 + 600 * 500 + 600 *1000} {100 + 200}");

Console.WriteLine($"Length od {strData} is = {strData.Length}");

Console.WriteLine($"First index of .NET is  = {strDataInformation.IndexOf(".NET")}");
Console.WriteLine($"Last Index of .NET is  = {strDataInformation.LastIndexOf(".NET")}");

// TO Read number of . in strDataInformation
// 1. REad each character of the string
// use can use for..loop or foreach..loop

Console.WriteLine("USing for..loop");
int count = 0;
for (int i = 0; i < strDataInformation.Length; i++)
{
    if (strDataInformation[i] == '.')
    { 
        count++;
    }
}
Console.WriteLine($"Using for...loop ount of . in {strDataInformation} is = {count}");
Console.WriteLine();
// resetting the counter
count = 0;  
Console.WriteLine("Using foreach..loop");
foreach (char c  in strDataInformation)
{
    if (c == '.')
    {
        count++;
    }
}
Console.WriteLine();
Console.WriteLine($"Using foreach...loop ount of . in {strDataInformation} is = {count}");
count = 0;
Console.WriteLine(  );
Console.WriteLine("Using while..loop");
int j = 0;
while (j < strDataInformation.Length)
{
    if (strDataInformation[j] == '.')
    {
        count++;
    }
    j++;
}
Console.WriteLine(  );
Console.WriteLine($"Using while...loop ount of . in {strDataInformation} is = {count}");
Console.WriteLine();
// USing char TYpe to process the string
// e.g. Read count of all whitespaces in the string strDataINformation
count = 0;
foreach (char c in strDataInformation)
{
    if (char.IsWhiteSpace(c))
    {
        count++;
    }

}

Console.WriteLine($"Using char type and its method count of <BLANKSPACES> in {strDataInformation} is = {count}");

var str1 = strData.Substring(4, 5);
Console.WriteLine($" read {strData} starts from 4th index and read 5 characters = {str1}");

Console.ReadLine();
