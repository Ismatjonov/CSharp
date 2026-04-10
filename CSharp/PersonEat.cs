using System.Security.Cryptography.X509Certificates;

namespace CSharp;

public partial class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    public partial string Name
    {
        get => name;
        set => name = value;
    }
    public void Eat() => Console.WriteLine("Man is eating!");

    public partial void Say(string message)
    {
        Console.WriteLine(message);
    }
}