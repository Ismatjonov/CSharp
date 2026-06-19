namespace MyApp;

class Program
{
    static void Main(string[] args)
    {
        var number = 5;
        var result =  Square(number);
        Console.WriteLine($"The result is {result}");
    }
    static int Square(int n) => n * n;
}

class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}