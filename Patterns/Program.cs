namespace Patterns;

class Program
{
    static void Main(string[] args)
    {
        Employee tom = new Employee("Tom", new Company("SilkRoad"));
        Employee? bob = new Manager("Bob", new Company("Farovon"), true);
        UseEmployee(tom);
        UseEmployee(bob);
        
        // Employee sam = new Manager() { IsOnVacation = true };
        // Employee john = new Manager() { IsOnVacation = false };
        // EmployeeUsage(sam);
        // EmployeeUsage(john);
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
        Person bakhtovar = new Person { Language = "tajik", Status = "user", Name = "Bakhtovar"};
        Person pierre = new Person { Language = "french", Status = "user", Name = "Pierre" };
        Person admin = new Person { Language = "english", Status = "admin", Name = "Admin" };

        Person tomas = new Person { Language = "german", Status = "admin", Name = "Tomas" };
        Person pablo = new Person { Language = "spanish", Status = "user", Name = "Pablo" };


        SayHello(bakhtovar);
        SayHello(pierre);
        SayHello(admin);

        Console.WriteLine();
        
        Console.WriteLine(GetMessage(tomas));
        Console.WriteLine(GetMessage(pablo));
        Console.WriteLine(GetMessage(pierre));
        Console.WriteLine(GetMessage(null));
        
        void SayHello(Person person)
        {
            if(person is Person { Language: "english", Status: "admin" })
                Console.WriteLine("Hello, admin");
            else if (person is Person { Language: "french"})
                Console.WriteLine("Salut");
            else
                Console.WriteLine("Salom");
        }

        string GetMessage(Person? p) => p switch
        {
            { Language: "english" } => "Hello!",
            { Language: "german", Status: "admin" } => "Hallo, admin!",
            { Language: "french", Name: var name } => $"Salut, {name}!",
            { Language: var lang} => $"Unknown language: {lang}",
            null => "null"
        };
        
        var microsoft = new Company("Microsoft");
        var google = new Company("Google");
        var nick = new Employee("Nick", microsoft);
        var ben = new Employee("Ben", google);
        PrintCompany(nick);
        PrintCompany(ben);

        void PrintCompany(Employee employee)
        {
            if(employee is { Company.Title: "Microsoft" } )
                Console.WriteLine($"{employee.Name} works in Microsoft");
            else
                Console.WriteLine($"{employee.Name} works somewhere");
        }

        Console.WriteLine();
        
        // Паттерны кортижей

        string msg = GetWelcome("english", "evening");
        Console.WriteLine(msg);

        msg = GetWelcome("french", "morning");
        Console.WriteLine(msg);

        Console.WriteLine(Getwelcome("english", "evening", "user"));
        Console.WriteLine(Getwelcome("french", "morning", "admin"));
        
        string GetWelcome(string lang, string daytime) => (lang, daytime) switch
        {
            ("english", "morning") => "Good morning",
            ("english", "evening") => "Good evening",
            ("german", "morning") => "Guten Morgen",
            ("german", "evening") => "Guten Abend",
            _ => "Здрасьть"
        };

        string Getwelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Здрасьть"
        };

        Console.WriteLine();
        // Position Pattern
        
        MessageDetails details1 = new MessageDetails { Language = "english", DateTime = "evening", Status = "user" };
        string m = getWelcome(details1);
        Console.WriteLine(m);  // Good evening
 
        MessageDetails details2 = new MessageDetails { Language = "french", DateTime = "morning", Status = "admin" };
        m = getWelcome(details2);
        Console.WriteLine(m);  // Hello, Admin
        
        string getWelcome(MessageDetails details) => details switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Здрасьть"
        };
        
    }
}

class Employee
{
    public string Name { get; }
    public Company Company { get; set; }

    public Employee(string name, Company company)
    {
        Name = name;
        Company = company;
    }
    public virtual void Work() => Console.WriteLine("Employee works.");
}

class Company
{
    public string Title { get; }
    public Company(string title) => Title = title;
}
class Manager : Employee
{
    public Manager(string name, Company company, bool isOnVacation) : base(name, company)
    {
        IsOnVacation = isOnVacation;
    }

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

class MessageDetails
{
    public string Language { get; set; } = "";
    public string DateTime { get; set; } = "";
    public string Status { get; set; } = "";

    public void Deconstruct(out string lang, out string datetime, out string status)
    {
        lang = Language;
        datetime = DateTime;
        status = Status;
    }
}