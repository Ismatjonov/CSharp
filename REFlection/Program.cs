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
        // Person tom = new("Tom", 27);
        // Type tomType = tom.GetType();
        // Console.WriteLine(tomType.Name);
        
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
        
        // --- Exploring Parameters ---
        foreach (MethodInfo method in printType.GetMethods())
        {
            Console.Write($"{method.ReturnType.Name} {method.Name} (");
            //получаем все параметры
            ParameterInfo[] parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                // получаем модификаторы параметра
                string modificator = "";
                if (param.IsIn) modificator = "in";
                else if (param.IsOut) modificator = "out";
 
                Console.Write($"{param.ParameterType.Name} {modificator} {param.Name}");
                // если параметр имеет значение по умолчанию
                if (param.HasDefaultValue) Console.Write($"={param.DefaultValue}");
                // если не последний параметр, добавляем запятую
                if (i < parameters.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(")");
        }
        Console.WriteLine();
        
        // --- Invoke() ---
        var myPrinter = new Printer("Hello World");
        var printer = typeof(Printer).GetMethod("Print");
        printer?.Invoke(myPrinter, null);
        
        // if method has private mod
        var thePrinter = new Printer("Hello METANIT.COM");
        
        var thePrint = typeof(Printer).GetMethod("Print", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        thePrint?.Invoke(thePrinter, null);
        
        // getting a result
        var tajikPrint = new Printer("Hello, Tajikistan!");
        var createMessage = typeof(Printer).GetMethod("CreateMessage");
        var result = createMessage?.Invoke(tajikPrint, parameters: null);
        Console.WriteLine(result);
        
        // Passing parameters
        var paramPrint = new Printer("Shonen Jump");
        var printMessage = typeof(Printer).GetMethod("PrintMessage");
        printMessage?.Invoke(paramPrint, new object[] { "Hello World", 3 });
        Console.WriteLine();
        
        // Calling a generic methods
        var p = new Printer("MILF");
        var printValue = typeof(Printer).GetMethod("PrintValue");
        var printStringValue = printValue?.MakeGenericMethod(typeof(string));
        printStringValue?.Invoke(p, new object[] {"Hello Khujand"});
        
        // --- Getting constructors ---
        Type type = typeof(Person);
        Console.WriteLine("Constructors:");
        foreach (ConstructorInfo ci in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public |
                                                            BindingFlags.NonPublic))
        {
            // getting mods
            string modificator = "";
            if (ci.IsPublic) modificator += "public ";
            else if (ci.IsPrivate) modificator += "private ";
            else if(ci.IsAssembly) modificator += "internal ";
            else if(ci.IsFamily) modificator += "protected ";
            else if(ci.IsFamilyAndAssembly) modificator += "private protected ";
            else if(ci.IsFamilyOrAssembly) modificator += "protected internal ";

            Console.Write($"{modificator} {type.Name} (");
            // getting constructor's params
            ParameterInfo[] parameters = ci.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                Console.Write($"{param.ParameterType.Name} {param.Name}");
                if (i < parameters.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(")");
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public Person(string name) : this(name, 1) { }
    private Person() : this("Tom") { }
    
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
    public string Text { get; set; }
    public Printer(string text) => Text = text;
    private void Print() => Console.WriteLine(Text);
    public string CreateMessage() => Text;

    public void PrintMessage(string message, int times)
    {
        while (times-- > 0) Console.WriteLine(message);
    }

    public void PrintValue<T>(T value)
    {
        Console.WriteLine(value);
    }
}