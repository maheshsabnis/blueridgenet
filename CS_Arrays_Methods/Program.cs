// See https://aka.ms/new-console-template for more information
Console.WriteLine("Array Methods");

int[] arr = new int[] { 10, 200, 13, 94,78,96,45,67,56,93,23,34,45,57,76,87,89 };

// 1. Lets Sort array

//Array.Sort(arr);

// 2. Reverse Array
// Array.Reverse(arr);
// 3.Clear array;
//Array.Clear(arr);


// 4. Copy one arry into another array

int[] arr2 = new int[arr.Length];
// COpy all records from arr to arr2
// from arr start reading from 4th index (0-based) and read 6 records from arr form 4th index
// and copy from 5th index (0-based) in arr2
Array.Copy(arr, 4, arr2, 5, 6);



Console.WriteLine("Printed Array");
foreach (int i in arr2)
{
    Console.WriteLine(i);
}

Console.ReadLine();
