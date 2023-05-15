// See https://aka.ms/new-console-template for more information
using CS_Polymorphsim.Logic;
using CS_Polymorphsim.Models;

Console.WriteLine("Accountat App");

Employee emp = new Director() 
{
  EmpNo = 101,EmpName="Mahesh",DeptName="IT",Salary=6000,FlightAllowance=4000,FoodAllowance=5000,VehicleAllowance = 9000
};

EmployeeLogic logic = new DirectorLogic();

Accounts accounts = new Accounts();  

// Call the GetTAx() method on Accounts class and pass Employee and EMployeeLogic to it

double tax = accounts.GetTax(emp, logic);

Console.WriteLine($"TAX = {tax}");


emp = new Manager() { EmpNo = 102, EmpName = "Kumar", DeptName = "HRD", Salary = 9000, PetrolAllownce = 9000, TravelAllowance = 8000 };

logic = new ManagerLogic();

tax = accounts.GetTax(emp, logic);
Console.WriteLine($"Tax = {tax}");




Console.ReadLine();
