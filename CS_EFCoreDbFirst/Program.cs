// See https://aka.ms/new-console-template for more information
using CS_EFCoreDbFirst.Models;
using System.Runtime.InteropServices;

Console.WriteLine("DEMO EF COre DB First");

CompanyContext context = new CompanyContext();

// 1. Get All Departments
ListAllDepartments(context);
// 2. Add NEw Department
// AddNewDepartment(context);

// 3. Update Department
//UpdateDepartment(context);
// 4. Delete Department
DeleteDepartment(context);
ListAllDepartments(context);



Console.ReadLine();

static void ListAllDepartments(CompanyContext context)
{
    var depts = context.Departments.ToList();
    foreach (var dept in depts)
    {
        Console.WriteLine($"{dept.DeptNo} {dept.DeptName}");
    }
}

static void AddNewDepartment(CompanyContext context)
{ 
    Department dept = new Department()
    { 
        DeptNo=100,DeptName="IT-Support",Capacity=9000,Location="Pune"    
    };
    context.Departments.Add(dept);
    context.SaveChanges();
}

static void UpdateDepartment(CompanyContext context)
{
    // search record based on Primary Key
    var d = context.Departments.Find(100);
    if (d == null)
        Console.WriteLine("No Department Found");
    else
    {
        d.DeptName = "IT-Support-Hardware";
        d.Capacity = 8000;
        d.Location = "Pune-West";

        context.SaveChanges();
    }
}

static void DeleteDepartment(CompanyContext context)
{
    // search record based on Primary Key
    var d = context.Departments.Find(100);
    if (d == null)
        Console.WriteLine("No Department Found");
    else
    {
         context.Departments.Remove(d);

        context.SaveChanges();
    }
}
