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
        
        // Паттерн свойст
        Person bakhtovar = new Person() { Language = "tajik", Status = "user", Name = "Bakhtovar"};
        Person pierre = new Person() { Language = "french", Status = "user", Name = "Pierre" };
        Person admin = new Person() { Language = "english", Status = "admin", Name = "Admin" };

        SayHello(bakhtovar);
        SayHello(pierre);
        SayHello(admin);
        
        void SayHello(Person person)
        {
            if(person is Person { Language: "english", Status: "admin" })
                Console.WriteLine("Hello, admin");
            else if (person is Person { Language: "french"})
                Console.WriteLine("Salut");
            else
                Console.WriteLine("Salom");
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

// Person Class here
class Person
{
    public string Name { get; set; } = "";  // имя пользователя
    public string Status { get; set; } = "";    // сиатус пользователя
    public string Language { get; set; } = "";  // язык пользователя
}