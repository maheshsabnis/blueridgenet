// See https://aka.ms/new-console-template for more information
using CS_Events;

Console.WriteLine("DEMO EVents");
Bank bank = new Bank(40000);
// Subscribe to EVentLstener to receive notifications
EventListener listener = new EventListener(bank);
Console.WriteLine($"Net Balance Before Transaction = {bank.GetNetBalance()}");
bank.Deposit(70000);
Console.WriteLine($"Net Balance after Deposit = {bank.GetNetBalance()}");
bank.Withdrawal(107000);
Console.WriteLine($"Net Balance after WIthdrawal = {bank.GetNetBalance()}");
Console.ReadLine();
