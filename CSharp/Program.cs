namespace CSharp;

class Program
{
    static void Main(string[] args)
    {
        var tom = new Person("Tom");
        tom.Eat();
        tom.Move();
        tom.Say("Hello, I'm Tom!");

        Console.WriteLine();

        var buffer = new Buffer();
        for(var i = 0; i < Buffer.COUNT; i++)
            buffer[i] = i * i;

        for (var i = 0; i < Buffer.COUNT; i++)
            Console.WriteLine(buffer[i]);
        Console.WriteLine();
        // Анонимные типы
        
        var user = new { Name = "Tom", Age = 34 };
        var student = new { Name = "Alice", Age = 21 };
        var manager = new { Name = "Bob", Age = 26, Company = "Microsoft" };
        
        Console.WriteLine(user.GetType().Name);
        Console.WriteLine(student.GetType().Name);
        Console.WriteLine(manager.GetType().Name);

        int age = 12;
        var pupil = new { tom.Name, age };
        Console.WriteLine(pupil.Name);
        Console.WriteLine(pupil.age);

        var people = new[]
        {
            new { Name = "Tom" },
            new { Name = "Bob" }
        };
        foreach (var p in people)
        {
            Console.WriteLine(p.Name);
        }
        
        // Задача
        User anna = new User() { Name = "Anna", Auto = new Auto() { Name = "Ford"} };
        int Age = 31;
        var teacher = new { anna.Auto.Name, Age };
        Console.WriteLine(teacher.Name);

    }
}

class Auto
{
    public string Name { get; set; }
}

class User
{
    public string Name { get; set; }
    public Auto Auto { get; set; }
}