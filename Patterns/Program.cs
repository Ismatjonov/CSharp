using System.Xml.Schema;

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
        
        MessageDetails details3 = new MessageDetails { Language = "chinese", DateTime = "night", Status = "moderator" };
        m = getWelcome(details3);
        Console.WriteLine(m);
        
        string getWelcome(MessageDetails details) => details switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            var (lang, datetime, status) => $"{lang} not found, {datetime} unknown, {status} undefined",
            _ => "Здрасьть"
        };
        Console.WriteLine();
        
        // Relation & Logical Patterns
        
        // Using relation pattern
        Console.WriteLine(Calculare(-200));
        Console.WriteLine(Calculare(0));
        Console.WriteLine(Calculare(10000));
        Console.WriteLine(Calculare(60000));
        Console.WriteLine(Calculare(200000));
        
        // Using logical pattern
        Console.WriteLine(CheckAge(200));
        Console.WriteLine(CheckAge(17));
        Console.WriteLine(CheckAge(0));
        Console.WriteLine(CheckAge(18));

        Console.WriteLine(checkAge(18));
        Console.WriteLine(checkAge(33));
        
        // relation pattern [<=, >=, <, >]
        decimal Calculare(decimal sum)
        {
            return sum switch
            {
                <= 0 => 0,
                < 50000 => sum * 0.05m,
                < 100000 => sum * 0.1m,
                _ => sum * 0.2m
            };
        }
        
        // logical pattern [or, and, not]
        string CheckAge(int age)
        {
            return age switch
            {
                < 1 or > 110 => "Недействительный возраст",
                >= 1 and < 18 => "Доступ запрещен",
                _ => "Доступ разрешен"
            };
        }

        string checkAge(int age) => age switch
        {
            not 33 => "Обычный возраст",
            _ => "Вам 33 года"
        };
        Console.WriteLine();
        
        // List Patterns
        Console.WriteLine(GetNumber(new[] { 1, 2, 3, 4, 5}));
        Console.WriteLine(GetNumber(new[] { 1, 2}));
        Console.WriteLine(GetNumber(new int[] {}));
        Console.WriteLine(GetNumber(new[] { 1, 2, 5}));

        int GetNumber(int[] values) => values switch
        {
            [1, 2, 3, 4, 5] => 1,
            [1, 2, 3] => 2,
            [1, 2] => 3,
            [] => 4,
            _ => 5
        };

        Console.WriteLine();
        List<int> numbers = new List<int> { 1, 2, 3 };
        Console.WriteLine(getNumber(numbers));
        
        int[] array = { 1, 2, 3, 4, 5 };
        if (array is [1, 2, 3, 4, 5])
        {
            Console.WriteLine("[1, 2, 3, 4, 5]");
        }
        Console.WriteLine();
        
        // Using _ pattern
        Console.WriteLine(getnumber(new[] { 2, 3, 5 }));
        Console.WriteLine(getnumber(new[] { 2, 4, 6 }));
        Console.WriteLine(getnumber(new[] { 1, 2, 5 }));
        Console.WriteLine(getnumber(new[] { 1, 2, 3 }));
        Console.WriteLine(getnumber(new int[] { }));
        
        
        int getNumber(List<int> numbers) => numbers switch
        {
            [1, 2, 3, 4, 5] => 1,
            [1, 2, 3] => 2,
            [1, 2] => 3,
            [] => 4,
            _ => 5
        };

        int getnumber(int[] values) => values switch
        {
            [2, _, 5] => 1,
            [2, _, _] => 2,
            [_, _, 5] => 3,
            [_, _, _] => 4,
            _ => 5
        };
        Console.WriteLine();
        
        // Slice Pattern [..]
        Console.WriteLine(Getnumber(new[] { 2, 5 }));
        Console.WriteLine(Getnumber(new[] { 2, 3, 4, 5 }));
        
        Console.WriteLine(Getnumber(new[] { 2 }));
        Console.WriteLine(Getnumber(new[] { 2, 3, 4 }));
        
        Console.WriteLine(Getnumber(new[] { 3, 4, 5 }));
        Console.WriteLine(Getnumber(new[] { 5 }));
        
        Console.WriteLine(Getnumber(new int[] { }));
        Console.WriteLine(Getnumber(new[] { 1 }));
        Console.WriteLine(Getnumber(new[] { 1, 2, 3 }));

        Console.WriteLine();

        Console.WriteLine(gn(new[] { 1, 2, 3, 4 }));
        Console.WriteLine(gn(new[] { 1, 2, 3 }));
        Console.WriteLine(gn(new[] { 1, 2 }));
        Console.WriteLine(gn(new[] { 1 }));
        Console.WriteLine(gn(new int[] { }));

        int Getnumber(int[] values) => values switch
        {
            [2, .., 5] => 1,
            [2, ..] => 2,
            [.., 5] => 3,
            [..] => 4
        };

        int gn(int[] values) => values switch
        {
            [_, .., _] => 1,
            [..] => 2
        };
        
        // Getting elements in variables
        int[] ints = { 2, 3, 5 };
        if (ints is [var first, var second, .., var last])
        {
            Console.WriteLine($"first: {first}, second: {second}, last: {last}");
        }
        Console.WriteLine();

        Console.WriteLine(GetData(new[] { 1, 2, 3 }));
        Console.WriteLine(GetData(new[] { 2, 4, 6, 8 }));
        Console.WriteLine(GetData(new[] { 1, 2 }));
        Console.WriteLine();
        string GetData(int[] values) => values switch
        {
            [var first, var second, .., var last] => $"First: {first}, Second: {second}, Last: {last}",
            [..] => "Array has less element than 3 elements"
        };

        Console.WriteLine(GetSlice(new[] { 2, 3, 4, 5 }));
        Console.WriteLine(GetSlice(new[] { 2, 4, 6, 8 }));
        Console.WriteLine(GetSlice(new[] { 1, 2, 3, 5 }));
        Console.WriteLine(GetSlice(new[] { 1, 2, 3, 4 }));
        Console.WriteLine(GetSlice(new int[] { }));
        Console.WriteLine();
        string GetSlice(int[] values) => values switch
        {
            [2, .. var middle, 5] => $"Middle: {string.Join(", ", middle)}",
            [2, .. var end] => $"End: {string.Join(", ", end)}",
            [.. var start, 5] => $"Start: {string.Join(", ", start)}",
            [.. var all] => $"All: {string.Join(", ", all)}",
        };
        
        // Collection's properties
        int[] nums = { 2, 3, 5 };
        if (nums is { Length: 3 } and [var _first, var _second, var _third])
        {
            Console.WriteLine($"First:{_first}, Second:{_second}, Third:{_third}");
        }
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