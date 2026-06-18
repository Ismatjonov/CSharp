using System.Diagnostics.CodeAnalysis;

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
        /*int[] numbers = { 1, 2, 3, 4, 5 };
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
        Console.WriteLine($"Average: {average}");*/
        
        // ========= Methods: Skip() & Take()
       /*string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
        var result = people.Skip(2);
        
        foreach(string person in result)
            Console.Write(person + " ");
        Console.WriteLine();
        
        var lastResult = people.SkipLast(2);
        
        foreach(var person in lastResult)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // ** SkipWhile() **
        var whileResult = people.SkipWhile(p => p.Length == 3);
        
        foreach(string person in whileResult)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // --- Take() ---
        var takeResult = people.Take(3);
        
        foreach(string person in takeResult)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // ** TakeLast **
        var takeLastResult = people.TakeLast(3);
        
        foreach(string person in takeLastResult)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // ** TakeWhile() **
        var takeWhileResult = people.TakeWhile(p => p.Length == 3);
        
        foreach(string person in takeWhileResult)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // ** Pagination output **
        var Result = people.Skip(3).Take(2);
        foreach(string person in Result)
            Console.Write(person + " ");
        Console.WriteLine();*/
        
       // ========== Grouping ==========
       /*Person[] people =
       {
           new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
           new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
           new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
       };

       var companies = from perosn in people
           group perosn by perosn.Company;

       foreach (var company in companies)
       {
           Console.WriteLine(company.Key);
           foreach (var person in company)
           {
               Console.WriteLine(person.Name);
           }
           Console.WriteLine();
       }
       
       // --- Creating new object when grouping ---
       var companies2 = from person in people
           group person by person.Company into g
               select new { Name = g.Key, Count = g.Count() };
       
       foreach(var company in companies2)
           Console.WriteLine($"{company.Name} : {company.Count}");
       
       // Or you can use
       var companies3 = people.GroupBy(person => person.Company).Select(g => new { Company = g.Key, Count = g.Count() });
       Console.WriteLine();
       
       // ---Nested queries ---
       var comps = from person in people
           group person by person.Company
           into g
           select new
           {
               Name = g.Key,
               Count = g.Count(),
               Employees = from p in g select p
           };

       foreach (var company in comps)
       {
           Console.WriteLine($"{company.Name} : {company.Count}");
           foreach (var person in company.Employees)
           {
               Console.WriteLine(person.Name);
           }
           Console.WriteLine();
       }*/
       
       // ========== Connecting collections ==========
       /*Person[] people =
       {
           new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
           new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft")
       };
       Company[] companies =
       {
           new Company("Microsoft", "C#"),
           new Company("Google", "Go"),
           new Company("Oracle", "Java")
       };
       var employees = from p in people
           join c in companies on p.Company equals c.Title
           select new { Name = p.Name, Company = c.Title, Language = c.Language };
       
       foreach(var e in employees)
           Console.WriteLine($"{e.Name} - {e.Company} ({e.Language})");
       Console.WriteLine();
       
       // --- method Join() ---
       var employees2 = people.Join(companies,
           p => p.Company,
           c => c.Title,
           (p, c) => new { Name = p.Name, Company = c.Title, Language = c.Language });
       
       foreach(var e in employees2)
           Console.WriteLine($"{e.Name} - {e.Company} ({e.Language})");
       Console.WriteLine();
       
       // --- GroupJoin ---
       var personnel = companies.GroupJoin(people,
           c => c.Title,
           p => p.Company,
           (c, employees) => new
           {
               Title = c.Title,
               Employees = employees
           });

       foreach (var company in personnel)
       {
           Console.WriteLine(company.Title);
           foreach(var emp in company.Employees)
               Console.WriteLine(emp.Name);
           Console.WriteLine();
       }
       
       // --- method Zip() ---
       var courses = new List<Course> { new Course("C#"), new Course("Java") };
       var students = new List<Student> { new Student("Tom"), new Student("Bob"), new Student("Mike") };

       var enrollments = courses.Zip(students);
       
       foreach(var enrollment in enrollments)
           Console.WriteLine($"{enrollment.First} - {enrollment.Second}");
       Console.WriteLine();*/
       
       // ========== Checking availability and retrieving items ==========
       /*string[] people = { "Tom", "Tim", "Bob", "Sam" };
       bool allHas3Chars = people.All(s => s.Length == 3);
       Console.WriteLine(allHas3Chars);

       bool alllStartWithT = people.All(s => s.StartsWith("T"));
       Console.WriteLine(alllStartWithT);
       
       // ** Any() **
       bool allHasMore3Chars = people.Any(s => s.Length > 3);
       Console.WriteLine(allHasMore3Chars);
       
       bool allStartsWithT = people.Any(s => s.StartsWith("T"));
       Console.WriteLine(allStartsWithT);
       
       // ** Contains() **
       bool hasTom = people.Contains("Tom");
       Console.WriteLine(hasTom);
       
       bool hasMike = people.Contains("Mike");
       Console.WriteLine(hasMike);
       
       // ** objects **
       Person[] people1 =
       {
           new Person("Tom"),
           new Person("Bob"),
           new Person("sam"),
       };
       var tom = new Person("Tom");
       var mike = new Person("Mike");
       bool hasTom1 = people1.Contains(tom);
       Console.WriteLine(hasTom1);
       
       bool hasMike1 = people1.Contains(mike);
       Console.WriteLine(hasMike1);

       // Diagnostic
       string[] people2 = { "tom","Tim", "bOb", "Sam" };

       bool hastom = people2.Contains("Tom", new CustomStringComparer());
       Console.WriteLine(hastom);
       
       bool hasbob = people2.Contains("Bob", new CustomStringComparer());
       Console.WriteLine(hasbob);
       
       // --- First/FirstOrdefault
       string[] people3 = { "Tom", "Tim", "Bob", "Sam" };
       
       var first  = people3.First();
       Console.WriteLine(first);
       
       string[] people4 = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };
       var firstWith4Chars = people4.First(f => f.Length == 4);
       Console.WriteLine(firstWith4Chars);
       
       // var firstWith5Chars = people4.First(f => f.Length == 5);
       // Console.WriteLine(firstWith5Chars);   // ! exception
       //
       // var First = new string[] { }.First(); ! exception
       // Console.WriteLine(First); 
       
       var _first = people4.FirstOrDefault();
       Console.WriteLine(_first);
       
       var _firstWith4Chars = people4.FirstOrDefault(f => f.Length == 4);
       Console.WriteLine(_firstWith4Chars);
       
       var firstOrDefault = new string[] {}.FirstOrDefault();
       Console.WriteLine(firstOrDefault);
       
       // Customize
       string? firstWith5Chars = people4.FirstOrDefault(f => f.Length == 5, "Undefined");
       Console.WriteLine(firstWith5Chars);
       
       string? _firstOrDefault = new string[] {}.FirstOrDefault("Hello");
       Console.WriteLine(_firstOrDefault);
       
       int fistNumber = new int[] {}.FirstOrDefault(100);
       Console.WriteLine(fistNumber);

       Console.WriteLine();

       // --- Last & LAstOrDefault
        string last = people4.Last();
        Console.WriteLine(last);
        
        string lastWith4Chars = people4.Last(s => s.Length == 4);
        Console.WriteLine(lastWith4Chars);
        
        // ** LastOrDefault **
        string? _last = people4.LastOrDefault();
        Console.WriteLine(_last);
        
        string? _lastWith4Chars = people4.LastOrDefault(s => s.Length == 4);
        Console.WriteLine(_lastWith4Chars);
        
        string? lastWith5Chars = people4.LastOrDefault(s => s.Length == 5);
        Console.WriteLine(lastWith5Chars);
        
        string? lastWith5CharsOrDefault = people4.LastOrDefault(s => s.Length == 5, "Undefined");
        Console.WriteLine(lastWith5CharsOrDefault);
        
        string? lastOrDefault = people4.LastOrDefault("hello");
        Console.WriteLine(lastOrDefault);*/
       
       // ========== Deferred and immediate execution of LINQ ==========
       /*string[] people = ["Tom", "Sam", "Bob"];
       var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);
       
       foreach(var person in selectedPeople)
           Console.WriteLine(person);
       
        var count = people.Where(s => s.Length == 3).OrderBy(s => s);
        Console.WriteLine(count.Count());

        // people[2] = "mike";
        Console.WriteLine(count.Count());
        
        // ** ToArray, ToDictionary **
        var selectedPeople2 = people.Where(s => s.Length == 3).OrderBy(s => s).ToList();
        people[2] = "Mike";
        
        foreach(var person in selectedPeople2)
            Console.WriteLine(person);*/
        
       // ========== Delegates in LINQ queries ==========
       string[] people = ["Tom", "Bob", "Kate", "Tim", "Mike", "Sam"];
       var result = people.Where(Length3);
       
       foreach(var person in result)
           Console.WriteLine(person);
       
       bool Length3(string name) => name.Length == 3;

       int[] numbers = [-2, -1, 0, 1, 2, 3, 4, 5, 6, 7];
       var _result = numbers.Where(i => i > 0).Select(Square);

       foreach (int n in _result)
       {
           Console.WriteLine(n);
       }
       int Square(int number) => number * number;

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

// record Person(string Name, string Company);
record Company(string Title, string Language);
record Course(string Title);
record Student(string Name);

class Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
    public override bool Equals(object? obj)
    {
        if (obj is Person person) return Name == person.Name;
        return false;
    }
    public override int GetHashCode() => Name.GetHashCode();
}

class CustomStringComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        if (x is null && y is null) return false;
        return x.ToLower() == y.ToLower();
    }
    public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
}

