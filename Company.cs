using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Company { get; set; }
}

class EmployeeManager
{
    private List<Employee> employees;

    public EmployeeManager()
    {
        // Initialize the list of employees (you can load actual data here).
        employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 30, Company = "CompanyA" },
            new Employee { Name = "Alice", Age = 28, Company = "CompanyA" },
            new Employee { Name = "Bob", Age = 35, Company = "CompanyB" },
            new Employee { Name = "Eva", Age = 29, Company = "CompanyB" },
        };
    }

    public Dictionary<string, int> AverageAgeForEachCompany()
    {
        var averageAges = employees
            .GroupBy(e => e.Company)
            .ToDictionary(
                group => group.Key,
                group => (int)Math.Round(group.Average(e => e.Age))
            );

        var sortedAverages = averageAges.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        return sortedAverages;
    }

    public Dictionary<string, int> CountOfEmployeesForEachCompany()
    {
        var employeeCounts = employees
            .GroupBy(e => e.Company)
            .ToDictionary(
                group => group.Key,
                group => group.Count()
            );

        var sortedCounts = employeeCounts.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        return sortedCounts;
    }

    public Dictionary<string, Employee> OldestAgeForEachCompany()
    {
        var oldestEmployees = employees
            .GroupBy(e => e.Company)
            .ToDictionary(
                group => group.Key,
                group => group.OrderByDescending(e => e.Age).First()
            );

        var sortedOldestEmployees = oldestEmployees.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        return sortedOldestEmployees;
    }
}

class Program
{
    static void Main()
    {
        var manager = new EmployeeManager();

        // Example of using the methods:
        var averageAges = manager.AverageAgeForEachCompany();
        var employeeCounts = manager.CountOfEmployeesForEachCompany();
        var oldestEmployees = manager.OldestAgeForEachCompany();

        // Display the results (example):
        Console.WriteLine("Average Ages:");
        foreach (var entry in averageAges)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} years");
        }

        Console.WriteLine("\nEmployee Counts:");
        foreach (var entry in employeeCounts)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} employees");
        }

        Console.WriteLine("\nOldest Employees:");
        foreach (var entry in oldestEmployees)
        {
            Console.WriteLine($"{entry.Key}: Oldest employee is {entry.Value.Name} (Age: {entry.Value.Age} years)");
        }
    }
}
