using System.Reflection;

namespace REFlection;

class Program
{
    static void Main(string[] args)
    {
        // Getting the type by typeog
        Type myType = typeof(Person);

        Console.WriteLine(myType.Name);
        
        // method GetType() : Object
        Person tom = new("Tom", 27);
        Type tomType = tom.GetType();
        Console.WriteLine(tomType.Name);
        
        // static method Type.GetType()
        Type? personType = Type.GetType("REFlection.Person", false, true);
        Console.WriteLine($"type is {personType.Name}");
        
        // additional info
        Type infoType = typeof(Person);

        Console.WriteLine($"Name: {infoType.Name}");
        Console.WriteLine($"Full Name: {infoType.FullName}");
        Console.WriteLine($"Namespace: {infoType.Namespace}");
        Console.WriteLine($"Is struct: {infoType.IsValueType}");
        Console.WriteLine($"Is class: {infoType.IsClass}");

        Console.WriteLine();
        // Search for implemented interfaces
        Console.WriteLine("Implemented interfaces:");
        foreach(Type i in infoType.GetInterfaces())
            Console.WriteLine(i.Name);
        Console.WriteLine();
        
        // ========== Using reflection and the study of types ==========
        foreach (MemberInfo mi in infoType.GetMembers())
        {
            Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
        }

        Console.WriteLine();
        // --- BindingFlags ---
        foreach (MemberInfo member in infoType.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                                                          BindingFlags.NonPublic | BindingFlags.Public))
        {
            Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
        }
        Console.WriteLine();
        
        // --- Getting only one component by name [GetMember()] ---
        MemberInfo[] print = infoType.GetMember("Print", BindingFlags.Instance | BindingFlags.Public);
        foreach(MemberInfo mi in print)
            Console.WriteLine($"{mi.MemberType} {mi.Name}");
        Console.WriteLine();
        
        // ========== Exploring Methods and Designers through Reflection ==========
        Type printType = typeof(Printer);
        Console.WriteLine("Methods: ");
        foreach (MethodInfo method in printType.GetMethods())
        {
            string modificator = "";
            
            if (method.IsStatic) modificator += "static ";
            if (method.IsVirtual) modificator += "virtual ";

            Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
        }
        Console.WriteLine();
        
        // ** BindingFlags **
        Console.WriteLine("methods:");
        foreach (MethodInfo method in printType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                                                           BindingFlags.NonPublic | BindingFlags.Public))
        {
            Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
        }
        Console.WriteLine();
    }
}

class Person
{
    string name;
    public int Age { get; set; }

    public Person(string name, int age)
    {
        this.name = name;
        Age = age;
    }
    public void Print() => Console.WriteLine($"Name: {name}, Age: {Age}");
}

interface IEater
{
    void Eat();
}

interface IMovable
{
    void Move();
}

class Printer
{
    public string DefaultMesage { get; set; } = "Hello";

    public void PrintMessage(string message, int times = 1)
    {
        while(times-- > 0) Console.WriteLine(message);
    }
    public string CreateMesage() => DefaultMesage;
}