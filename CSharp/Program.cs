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

        int _age = 12;
        var pupil = new { tom.Name, _age };
        Console.WriteLine(pupil.Name);
        Console.WriteLine(pupil._age);

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
        Console.WriteLine();
        
        // Кортежи
        // var tuple = (5, 10); // Неявным образом
        (int, int) tuple = (5, 10); // Явным образом
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item2);
        tuple.Item1 += 26;
        Console.WriteLine(tuple.Item1);
        (string, int, double) person = ("Tom", 25, 81.23);
        Console.WriteLine(person);
        var tuple1 = (count: 5, sum: 10);
        Console.WriteLine(tuple1.count);
        Console.WriteLine(tuple1.sum);
        
        // Декомпозиция кортежа
        var (name, age) = ("Tom", 23);
        Console.WriteLine(name);
        Console.WriteLine(age);

        // Одной из задач, которую позволяет элегантно решить кортеж - это обмен значениями!!
        string main = "Java";
        string second = "C#";
        (main, second) = (second, main);
        Console.WriteLine(main);
        Console.WriteLine(second);
        
        // Сортировка массива
        int[] nums = { 54, 7, -41, 2, 4, 2, 89, 33, -5, 12 };
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] < nums[j])
                    (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }

        Console.WriteLine("Output of sorted array:");
        foreach (var i in nums)
            Console.Write(i + " ");
        Console.WriteLine();

        var tuple2 = GetValue();
        Console.WriteLine(tuple2.Item1);
        Console.WriteLine(tuple2.Item2);

        (int, int) GetValue()
        {
            var result = (1, 3);
            return result;
        }
        
        var tuple3 = GetValueData(new int[] { 1, 2, 3, 4, 5, 6, 7 });
        Console.WriteLine(tuple3.count);
        Console.WriteLine(tuple3.sum);

        (int sum, int count) GetValueData(int[] numbers)
        {
            var result = (sum: 0, count: numbers.Length);
            foreach (var n in numbers)
            {
                result.sum += n;
            }
            return result;
        }
        
        // Кортеж как параметр метода
        PrintPerson(("Tom", 37));
        PrintPerson(("Bob", 41));
        void PrintPerson((string name, int age) person)
        {
            Console.WriteLine($"{person.name} - {person.age}");
        }
        
        // Records
        var bmw = new Car("BMW", 2022);
        // bmw.Name = "Mercedes-Benz";  // Нельзя изменить инизиализированное сначение, так как у нас модификатор init
        Console.WriteLine(bmw.Name);
        
        var car1 = new Car("Toyota", 2011);
        var car2 = new Car("Toyota", 2011);
        Console.WriteLine(car1.Equals(car2));
        Console.WriteLine(car1 == car2);
        
        var book1 = new Book("Atomic Habits");
        var book2 = new Book("Atomic Habits");
        Console.WriteLine(book1.Equals(book2));
        Console.WriteLine(book1 == book2);
        
        // Оператор with
        var honda = new Car("Honda", 2016);
        var opel = honda with { Name = "Opel" };
        var crv = honda with { };
        Console.WriteLine($"{opel.Name} - {opel.Year}");
        Console.WriteLine($"{crv.Name} - {crv.Year}");

        var kia = new Car("Kia", 2024);
        Console.WriteLine(kia.Name);
        var (varName, varYear) = kia;
        Console.WriteLine(varName);
        Console.WriteLine(varYear);
        Console.WriteLine();
        
        var ford = new Car("Ford", 2023) { Color = "Black" };
        Console.WriteLine(ford.Color);
        ford.Color = "Blue";
        Console.WriteLine(ford.Color);
        Console.WriteLine();

        var cat = new Animal("Moshon", 3);
        cat.Name = "Murka"; // Значение исменилось, так как это struct а не class
        Console.WriteLine(cat.Name);
        
        // ToString()
        var mercedes = new Car("Mercedes", 2025);
        Console.WriteLine(mercedes);
        
        // Наследование
        var ferrari = new Car("Supra", 2014);
        var supra = new Supercar("Supra", 2006, "Toyota Motors");
        Console.WriteLine(ferrari);
        Console.WriteLine(supra);
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