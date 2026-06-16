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
        
    }
}