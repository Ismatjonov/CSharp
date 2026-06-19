namespace DLR;

class Program
{
    static void Main(string[] args)
    {
        dynamic x = 3;
        Console.WriteLine(x);
        
        x = "Hello World!";
        Console.WriteLine(x);

        x = new Person("Tom", 37);
        Console.WriteLine(x);

        object obj = 24;
        dynamic dyn = 24;
        // obj += 4;   // error!
        dyn += 4;
        Console.WriteLine();
        
        dynamic tom = new Person("Tom", 22);
        Console.WriteLine(tom);
        Console.WriteLine(tom.GetSalary(28, "int"));
        
        dynamic bob = new Person("Bob", "twenty-two");
        Console.WriteLine(bob);
        Console.WriteLine(bob.GetSalary("twenty-eight", "string"));
    }
}

class Person
{
    public string Name { get; set; }
    public dynamic Age { get; set; }

    public Person(string name, dynamic age)
    {
        Name = name;
        Age = age;
    }
    // output salary depends on passed format
    public dynamic GetSalary(dynamic value, string format)
    {
        if (format == "string") return $"{value} euro";
        else if (format == "int") return value;
        else return 0.0;
    }
    public override string ToString() => $"Name: {Name}, Age: {Age}";
}