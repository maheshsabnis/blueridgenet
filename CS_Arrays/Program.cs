// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Array");

int[]arr = new int[5];
// Lets add data  in array

for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine($"ENter value for index {i}");
    arr[i] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine(  );
Console.WriteLine("Data in Array");
int j = 0;
foreach (int i in arr)
{
    Console.WriteLine($" Data in array at index {j} is = {i}");
    j++;
}


 




Console.ReadLine();
