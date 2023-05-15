using CS_SImpleClass.Models;

Console.WriteLine("DEMO Simple Class");
// USe EMployee
// Defined an instance by passing parameters to constructor
Employee emp = new Employee(101, "Mahesh", "IT", "Manager",340000);
// Call the methdo from the class
decimal NetSalary = emp.CalculateNetSalary();

Console.WriteLine($"Net Salary : {NetSalary}");


Console.ReadLine();
