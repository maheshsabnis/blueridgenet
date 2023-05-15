using CS_LINQ.Models;
using CS_LINQ.Database;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information

Console.WriteLine("DEMO LINQ");

EmployeesDb db = new EmployeesDb();

//foreach (Employee emp in db)
//{
//    if (emp.DeptName == "D1" && emp.Salary < 40000 && emp.EmpName.StartsWith('E'))
//    {
//        Console.WriteLine($"{JsonSerializer.Serialize(emp)}");
//    }
//}

// IMperative Queries using Extension Methods e.g. Where(), Select(), OrderBy(), etc.

Console.WriteLine("All D1 EMployees");
var employees = db.Where(e => e.DeptName == "D1").ToList();
Console.WriteLine($"{JsonSerializer.Serialize(employees)}");
Console.WriteLine(  );
Console.WriteLine("Salaey Less than 40000");
var employeesWithSalaryLessThan4000 = employees.Where(e => e.Salary < 40000);
Console.WriteLine($"{JsonSerializer.Serialize(employeesWithSalaryLessThan4000)}");
Console.WriteLine();
Console.WriteLine("Order All EMployees by Descending Order by EMpName");
var employeesByDescendinOrderByEMpNAme = employeesWithSalaryLessThan4000.OrderByDescending(e => e.EmpName);
Console.WriteLine($"{JsonSerializer.Serialize(employeesByDescendinOrderByEMpNAme)}");

Console.WriteLine(  );

Console.WriteLine("Sum of Salary for Employees Group by DeptName");
// The Declarateive Queries Like SQL Statements
// select will map to Select() Extension Method
// where will map to Where()
// group by will map to GroupBy()

var sumSalaryGroupByDeptName = from emp in db
                               group emp by emp.DeptName into empdept
                               select new /* Anonymous Type (Class Instance w/o name)*/
                               {
                                   DeptName = empdept.Key, // The Property on which group is created 
                                   Salary = empdept.Sum(e => e.Salary)
                               };


foreach (var item in sumSalaryGroupByDeptName)
{
    Console.WriteLine($"DeptName = {item.DeptName} Salary = {item.Salary}");
}

Console.WriteLine(  );

var result = from emp in db
             where emp.DeptName == "D1"
             select emp;

foreach (var item in result)
{ 
    Console.WriteLine(JsonSerializer.Serialize(item));
}


Console.WriteLine("EMployees Order By Salary");

var empsOrderBySalary = from emp in db
                        orderby emp.Salary descending
                        select emp;

Console.WriteLine(JsonSerializer.Serialize(empsOrderBySalary));



Console.ReadLine();
