namespace Patterns;

class Program
{
    static void Main(string[] args)
    {
        Employee tom = new Employee();
        Employee bob = new Manager();
        UseEmployee(tom);
        UseEmployee(bob);
        
        Employee sam = new Manager() { IsOnVacation = true };
        Employee john = new Manager() { IsOnVacation = false };
        EmployeeUsage(sam);
        EmployeeUsage(john);
        // UseEmployee(tom);
        
        // Employee? bob = new Employee();
        // Employee? anna = null;
        
        // Use(bob);
        // Use(anna);

        void Use(Employee? e)
        {
            if (e is not null)
                e.Work();
        }
        
        // void UseEmployee(Employee emp)
        // {
        //     if (emp is Manager manager && manager.IsOnVacation == false)
        //     {
        //         manager.Work();
        //     }
        //     else
        //     {
        //         Console.WriteLine("Employee is not manager.");
        //     }
        // }
        
        var message = "hello";
        if (message is "hello")
        {
            Console.WriteLine("hello");
        }
        
        // Использование конструкции switch
        void UseEmployee(Employee? emp)
        {
            switch (emp)
            {
                case Manager manager:
                    manager.Work();
                    break;
                case null:
                    Console.WriteLine("Object is null");
                    break;
                default:
                    Console.WriteLine("Object is not manager");
                    break;
            }
        }

        void EmployeeUsage(Employee? emp)
        {
            switch (emp)
            {
                case Manager manager when !manager.IsOnVacation:
                    manager.Work();
                    break;
                case null:
                    Console.WriteLine("Employee is null");
                    break;
                default:
                    Console.WriteLine("Employee does mot work");
                    break;
            }
        }
    }
}

class Employee
{
    public virtual void Work() => Console.WriteLine("Employee works.");
}

class Manager : Employee
{
    public override void Work() => Console.WriteLine("Manager works.");
    public bool IsOnVacation { get; set; }
}