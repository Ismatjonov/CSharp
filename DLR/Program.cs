using System.Dynamic;

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
        Console.WriteLine();
        
        // ========== DynamicObject & ExpandoObject ==========
        dynamic person = new System.Dynamic.ExpandoObject();
        person.Name = "Tom";
        person.Age = 46;
        person.Language = new List<string> {"englisg", "german","french"};

        Console.WriteLine($"{person.Name} - {person.Age}");
        foreach(var lang in person.Language)
            Console.WriteLine(lang);
        
        // methods
        person.IncrementAge = (Action<int>)(x => person.Age += x);
        person.IncrementAge(6);
        Console.WriteLine($"{person.Name} - {person.Age}");
        Console.WriteLine();
        
        // --- DynamicObject() ---
        dynamic person2 = new PersonObject();
        person2.Name = "Tom";
        person2.Age = 23;
        
        Func<int, int> increment = (int n) => { person2.Age += n; return person2.Age; };
        person2.IncrementAge = increment;

        Console.WriteLine($"{person2.Name} - {person2.Age}");
        person2.IncrementAge(4);
        Console.WriteLine($"{person2.Name} - {person2.Age}");
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

class PersonObject : DynamicObject
{
    Dictionary<string, object> members = new Dictionary<string, object>();

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        if (value is not null)
        {
            members[binder.Name] = value;
            return true;
        }
        return false;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = null;
        if (members.ContainsKey(binder.Name))
        {
            result = members[binder.Name];
            return true;
        }
        return false;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        result = null;
        if (args?[0] is int number)
        {
            dynamic method = members[binder.Name];
            result = method(number);
        }
        return result != null;
    }
}