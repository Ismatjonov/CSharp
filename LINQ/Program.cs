namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
        // The basic of LINQ
        /*
        string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
        var selectedPeople = new List<string>();
        
        foreach(string person in people)
            if (person.ToUpper().StartsWith("T"))
                selectedPeople.Add(person);
        
        selectedPeople.Sort();
        
        foreach(string person in selectedPeople)
            Console.WriteLine(person);
        Console.WriteLine();
        
        // --- LINQ query operators ---
        var linqSelectedPeople = from p in people
            where p.ToUpper().StartsWith("T")
            orderby p
            select p;
        
        foreach(string person in linqSelectedPeople)
            Console.WriteLine(person);
        Console.WriteLine();
        
        // --- LINQ extension methods ---
        string[] people2 = { "Tom", "Bob","Tomas", "Sam", "Tim" };
        var selectedPeople2 = people2.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
        
        foreach(string person in selectedPeople2)
            Console.WriteLine(person);
        Console.WriteLine();
        
        // Selects' methods
        // ========== Data projection ==========
        var people3 = new List<Person>
        {
            new Person("Tom", 23),
            new Person("Bob", 27),
            new Person("Sam", 29),
            new Person("Alice", 24)
        };
        
        var names = from p in people3 select p.Name;
        
        foreach(string name in names)
            Console.WriteLine(name);
        Console.WriteLine();
        
        // ** Using extension method Select() **
        var names2 = people3.Select(u => u.Name);
        foreach(string name in names2)
            Console.WriteLine(name);
        Console.WriteLine();
        
        // --- creating new objects, even anonymous ---
        var people4 = new List<Person>
        {
            new Person("Tom", 23),
            new Person("Bob", 27),
        };
        var personal = from p in people4
            select new
            {
                FirstName = p.Name,
                Year = DateTime.Now.Year - p.Age
            };
        
        foreach(var p in personal)
            Console.WriteLine($"{p.FirstName} - {p.Year}");
        Console.WriteLine();
        
        // ** Alternatives **
        var personal2 = people4.Select(p => new
        {
            FirstName = p.Name,
            Year = DateTime.Now.Year - p.Age
        });
        foreach (var p2 in personal2)
            Console.WriteLine($"{p2.FirstName} - {p2.Year}");
        Console.WriteLine();
        
        // --- Variables in queries and the let operator ---
        var people5 = new List<Person>
        {
            new Person("Tom", 23),
            new Person("Bob", 27)
        };
        var personnel = from p in people5
            let name = $"Mr. {p.Name}"
            let year = DateTime.Today.Year - p.Age
            select new
            {
                Name = name,
                Year = year
            };
        foreach(var p in personnel)
            Console.WriteLine($"{p.Name} - {p.Year}");
        Console.WriteLine();
        
        // --- Selection from several sources ---
        var courses = new List<Course> { new Course("C#"), new Course("Java") };
        var students = new List<Student> { new Student("Tom"), new Student("Bob") };
        
        var enrollments = from course in courses
            from student in students
            select new { Student = student.Name, Course = course.Title };

        foreach (var enrollment in enrollments)
            Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");
        Console.WriteLine();
        
        // --- SelectMany & object flattening ---
        var companies = new List<Company>
        {
            new Company("Microsoft", new List<Employee> { new Employee("Tom"), new Employee("Bob") }),
            new Company("Google", new List<Employee> { new Employee("Mike"), new Employee("Sam") }),
        };
        var employees = companies.SelectMany(c => c.Staff);
        
        foreach(var employee in employees)
            Console.WriteLine(employee.Name);
        Console.WriteLine();
        
        // ** A similar example using LINQ operations **
        var employess2 = from c in companies
            from emp in c.Staff
            select emp;
        
        foreach(var employee in employess2)
            Console.WriteLine(employee.Name);
        Console.WriteLine();
        
        // --- Add to employees their companies ---
        var employees3 = companies.SelectMany(c => c.Staff, (c, emp) => new {Name = c.Name, Employees = emp.Name});
        
        foreach(var employee in employees3)
            Console.WriteLine($"{employee.Employees} - {employee.Name}");
        Console.WriteLine();
        
        // ** A similar example using query operations **
        var employees4 = from c in companies
            from emp in c.Staff
            select new { Name = c.Name, Employees = emp.Name };
        
        foreach(var employee in employees4)
            Console.WriteLine($"{employee.Name} - {employee.Employees}");
        Console.WriteLine();
        */
        
        // ========== Filtering a collection ==========
        /*
        string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };
        var selectedPeople = people.Where(p => p.Length == 3);
        
        foreach(string person in selectedPeople)
            Console.WriteLine(person);
        Console.WriteLine();

        int[] numbers = { 1, 2, 3, 4, 34, 10, 55, 56, 66, 67, 69, 77, 88 };
        var selectedNumbers = numbers.Where(i => i % 2 == 0 && i > 10);
        foreach(int number in selectedNumbers)
            Console.Write(number + " ");
        Console.WriteLine();
        
        // --- Selection of complex objects ---
        var people2 = new List<Person>
        {
            new Person("Tom", 23, new List<string> { "english", "german" }),
            new Person("Bob", 27, new List<string> { "english", "french" }),
            new Person("Sam", 29, new List<string> { "english", "spanish" }),
            new Person("Alice", 24, new List<string> { "spanish", "german" }),
        };
        var selectedPerson = from p in people2
            where p.Age > 25
                select p;
        foreach(var person in selectedPerson)
            Console.WriteLine($"{person.Name} - {person.Age}");
        Console.WriteLine();
        
        // --- Complex filtering ---
        var selectedPerson2 = from person in people2
            from land in person.Languages
            where person.Age > 25
                where land == "spanish"
                select person;

        foreach (var person in selectedPerson2)
            Console.WriteLine($"{person.Name} - {person.Age}");
        Console.WriteLine();
        
        var selectedManyPerson = people2.SelectMany(u => u.Languages,
            (u, l) => new { Person = u, Language = l })
            .Where(u => u.Language == "english" && u.Person.Age < 28)
            .Select(u => u.Person);
        
        foreach(var person in selectedManyPerson)
            Console.WriteLine($"{person.Name} - {person.Age}");
        Console.WriteLine();
        */
        
        // --- Filtering by data type ---
        // var people = new List<Person>
        // {
        //     new Student("Tom"),
        //     new Person("Sam"),
        //     new Student("Bob"),
        //     new Employee("Mike")
        // };
        // var students = people.OfType<Student>();
        // foreach(var student in students)
        //     Console.WriteLine(student.Name);
        // Console.WriteLine();
        
        // ========== Sorting ==========
        /*int[] numbers = { 3, 12, 4, 10 };
        var orderedNumbers = from i in numbers
            orderby i
                select i;
        
        foreach(int i in orderedNumbers)
            Console.WriteLine(i);
        Console.WriteLine();

        string[] people = { "Tom", "Bob", "Sam" };
        var orderedPeople = from p in people orderby p select p;
        foreach(string p in orderedPeople) Console.WriteLine(p);
        Console.WriteLine();
        
        // ** Extension method: OrderBy() **
        var orderNumber = numbers.OrderBy(n => n);
        foreach(int n in orderNumber) Console.WriteLine(n);
        Console.WriteLine();
        
        var orderPeople = people.OrderBy(p => p);
        foreach(string p in orderPeople) Console.WriteLine(p);
        Console.WriteLine();*/
        
        // --- Sorting complex methods ---
        /*var people = new List<Person>
        {
            new Person("Tom", 37),
            new Person("Sam", 28),
            new Person("Tom", 22),
            new Person("Bob", 41)
        };
        var selectedPeople1 = from p in people
            orderby p.Name
                select p;
        foreach(var person in selectedPeople1)
            Console.WriteLine($"{person.Name} - {person.Age}");
        Console.WriteLine();
        
        var sortedPeople2 = people.OrderBy(p => p.Name);
        foreach(var person in sortedPeople2)
            Console.WriteLine($"{person.Name} - {person.Age}");
        Console.WriteLine();*/
        
        // --- Sort in ascending and descending order ---
        /*int[] numbers = { 3, 12, 4, 10 };
        var orderedNumbers = from n in numbers
            orderby n descending
                select n;
        foreach(int n in orderedNumbers) Console.WriteLine(n);
        Console.WriteLine();
        
        var orderedWithNethod = numbers.OrderByDescending(n => n);
        foreach(int n in orderedWithNethod) Console.WriteLine(n);
        Console.WriteLine();
        
        // --- Multiple sorting criteria ---
        var people = new List<Person>
        {
            new Person("Tom", 37),
            new Person("Sam", 28),
            new Person("Tom", 22),
            new Person("Bob", 41),
        };
        
        var sortedPeople1 = from p in people
            orderby p.Name, p.Age
                select p;
        foreach(Person p in sortedPeople1) Console.WriteLine($"{p.Name} - {p.Age}");
        Console.WriteLine();
        
        var sortedPeople2 = people.OrderBy(p => p.Name).ThenByDescending(p => p.Age);
        foreach(Person p in sortedPeople2) Console.WriteLine($"{p.Name} - {p.Age}");
        Console.WriteLine();*/
        
        // --- Overriding the sorting criteria ---
        // string[] people = new[] { "Kate", "Tom", "Sam", "Mike", "Alice" };
        // var sortedPeople = people.OrderBy(p => p, new CustomStringComparer());
        // foreach(var person in sortedPeople)
        //     Console.WriteLine(person);
        // Console.WriteLine();
        
        // ========== Union, intersection, and difference of collections ==========
        /*string[] soft = { "Microsoft", "Google", "Apple" };
        string[] hard = { "Apple", "IBM", "Samsung" };
        
        // ** Difference of sequences **
        var result = soft.Except(hard);
        foreach(string item in result)
            Console.WriteLine(item);
        Console.WriteLine();
        
        // ** Intersection of sequences **
        var result2 = soft.Intersect(hard);
        foreach(string item in result2)
            Console.WriteLine(item);
        Console.WriteLine();
        
        // ** Removing dublicates **
        string[] soft2 = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };
        
        var result3 = soft2.Distinct();
        
        foreach(string item in result3)
            Console.WriteLine(item);
        Console.WriteLine();

        // ** Union sequences **
        string[] soft3 = { "Microsoft", "Google", "Apple" };
        string[] hard3 = { "Apple", "IBM", "Samsung" };
        
        var result4 = soft3.Union(hard3);
        foreach(string item in result4)
            Console.WriteLine(item);
        Console.WriteLine();
        
        // ** Work with complex objects **
        Person[] students = new[] { new Person("Tom"), new Person("Bob"), new Person("Sam") };
        Person[] employees = new[] { new Person("Tom"), new Person("Bob"), new Person("Mike") };
        
        var people = students.Union(employees);
        
        foreach(var item in people)
            Console.WriteLine(item.Name);
        Console.WriteLine();*/
        
        // ========== Aggregate operations ==========
        int[] numbers = { 1, 2, 3, 4, 5 };
        int query = numbers.Aggregate((x, y) => x - y);
        Console.WriteLine(query);

        string[] words = { "Gaudeamus", "igitur", "Juvenes", "dum", "sumus" };
        var sentences = words.Aggregate("Text:", (first, next) => $"{first} {next}");
        Console.WriteLine(sentences);
        
        // ** mathod Count() **
        int[] numbers2 = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
        int size = numbers2.Count();
        Console.WriteLine(size);
        
        int evenSize = numbers2.Count(x => x % 2 == 0 && x > 10);
        Console.WriteLine(evenSize);
        
        // ** method Sum() **
        int sum = numbers2.Sum();
        Console.WriteLine(sum);
        
        Person[] people = { new Person("Tom", 37), new Person("Bob", 27), new Person("Jane", 41) };

        int ageSum = people.Sum(p => p.Age);
        Console.WriteLine(ageSum);
        
        // ** Max, Min & Average
        int min = numbers2.Min();
        int max = numbers2.Max();
        double average = numbers2.Average();

        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine();
        
        min = people.Min(p => p.Age);
        max = people.Max(p => p.Age);
        average = people.Average(p => p.Age);
        
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Average: {average}");
    }
}
// record  Person(string Name, int Age);
// record Student(string Name) : Person(Name);
// record  Employee(string Name) : Person(Name);
// record Course(string Title);
// record Company(string Name, List<Employee> Staff);

/*class CustomStringComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        int xLength = x?.Length ?? 0;
        int yLength = y?.Length ?? 0;
        return xLength - yLength;
    }
}*/
/*class Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;

    public override bool Equals(object? obj)
    {
        if (obj is Person person) return Name == person.Name;
        return false;
    }
    public override int GetHashCode() => Name.GetHashCode();
}*/

record Person(string Name, int Age);