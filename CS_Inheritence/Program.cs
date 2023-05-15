using CS_Inheritence.Models;
using CS_Inheritence.Logic;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Inheritence");

Director director = new Director(); 
director.EmpNo = 1;
director.EmpName = "ABC";
director.DeptName = "IT";
director.Salary = 4000;
director.FlightAllowance = 700;
director.FoodAllowance = 800;
director.VehicleAllowance = 900;

DirectorLogic directorLogic = new DirectorLogic();

var employees = directorLogic.AddEmployee(director);



var directornetsala = directorLogic.GetNetSalary(director);

Console.WriteLine($"All Director EMployees {JsonSerializer.Serialize(employees)} and Salary = {directornetsala}");


Manager manager = new Manager();
manager.EmpNo = 2;
manager.EmpName = "XYZ";
manager.DeptName = "HR";
manager.Salary = 3000;

manager.TravelAllowance = 900;
manager.PetrolAllownce = 777;

ManagerLogic managerLogic = new ManagerLogic();

var empmanagers = managerLogic.AddEmployee(manager);
var managernewtsalary = managerLogic.GetNetSalary(manager);


Console.WriteLine($"All Manager EMployees {JsonSerializer.Serialize(empmanagers)} and Salary = {managernewtsalary}");


Console.ReadLine(); 
