namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
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
    }
}
record  Person(string Name, int Age);