using System;

class Employee
{
    private string surname;
    private string firstName;

    public Employee(string surname, string firstName)
    {
        this.surname = surname;
        this.firstName = firstName;
    }

    public void CalculateSalary(string position, int experience)
    {
        double baseSalary = 0.0;
        double taxRate = 0.1; // 10% tax rate

        // Logic to calculate baseSalary based on position and experience
        // (For example purposes, using a simple calculation)
        switch (position.ToLower())
        {
            case "manager":
                baseSalary = 3000.0;
                break;
            case "developer":
                baseSalary = 2500.0;
                break;
            default:
                baseSalary = 2000.0;
                break;
        }

        double totalSalary = baseSalary + (experience * 100.0);
        double tax = totalSalary * taxRate;

        Console.WriteLine($"Employee Information:");
        Console.WriteLine($"Surname: {surname}");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Base Salary: {baseSalary:0.00} UAH");
        Console.WriteLine($"Experience Bonus: {experience * 100.0:0.00} UAH");
        Console.WriteLine($"Total Salary: {totalSalary:0.00} UAH");
        Console.WriteLine($"Tax: {tax:0.00} UAH");
        Console.WriteLine($"Net Salary: {totalSalary - tax:0.00} UAH");
    }
}

class Program
{
    static void Main()
    {
        Employee employee = new Employee("Smith", "John");
        employee.CalculateSalary("Developer", 5);
    }
}
