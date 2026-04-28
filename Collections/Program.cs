using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Collections;

class Program
{
    static void Main(string[] args)
    {
        // List<string> people = new List<string>() { "Tom", "Bob", "Sam" };
        // var employees = new List<string>(people) {"Mike"};

        // List<string> people = ["Tom", "Bob", "Sam"];
        // List<string> employees = [];
        
        // List<string> personals = new List<string>(16);   // Set beginning capacity

        // List<Person> people = new List<Person>()
        // {
        //     new Person("Tom"),
        //     new Person("Bob"),
        //     new Person("Sam"),
        // };
        
        // var people = new List<string>() {"Tom", "Bob", "Sam"};
        // string firstPerson = people[0];
        // Console.WriteLine(firstPerson);
        // people[0] = "Mike";
        // Console.WriteLine(people[0]);
        //
        // Console.WriteLine(people.Count);
        //
        // foreach (var person in people)
        // {
        //     Console.WriteLine(person);
        // }
        //
        // for (int i = 0; i < people.Count; i++)
        // {
        //     Console.WriteLine(people[i]);
        // }
        
        // USING ALL METHODS
        // =================== 
        
        // Adding
        List<string> people = new List<string>() { "Tom" };
        people.Add("Bob");  // Add element
        people.AddRange(new[] {"Sam", "Alice"});    // Add array(collection)
        people.Insert(0, "Eugene"); // Insert in the first place
        people.InsertRange(1, new string[] { "Mike", "Kate" }); // Insert array with index 1
        foreach(var person in people)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // Removing
        people.RemoveAt(1); // Removing second element
        people.Remove("Tom");   // Removing element "Tom"
        people.RemoveAll(person => person.Length == 3); // Removing all element that length is equal to 3
        people.RemoveRange(1, 2);   // Removing from list 2 elements starting with index 1
        people.Clear();
        
        // Search and checking elements
        people.AddRange(new[] {"Eugene", "Mike", "Kate", "Tom", "Bob", "Sam"});
        
        var containsBob = people.Contains("Bob");   // true
        var containsBill = people.Contains("Bill"); // false
        
        // checking is there string with length 3 symbols
        var existLength3 = people.Exists(person => person.Length == 3);  // true
        
        // checking is there string with length 7 symbols
        var existLength7 = people.Exists(person => person.Length == 7); // false
        
        //  Getting first element with length 3 symbols
        var firstWithLength3 = people.Find(person => person.Length == 3);  // Tom
        
        // Getting last element with length 3 symbols
        var lastWithLength3 = people.FindLast(person => person.Length == 3);  // Sam
        
        // Getting  all elements with length 3 as a collection
        List<string> peopleWithLength3 = people.FindAll(person => person.Length == 3);
        foreach (var person in peopleWithLength3)
            Console.Write(person + " ");
        Console.WriteLine();
        people.Clear();
        
        // Getting range & cloning into the array
        people.AddRange(new[] { "Eugene", "Tom", "Mike", "Sam", "Bob" });
        
        // Getting range from second to forth element
        var range = people.GetRange(1, 3);  // ["Tom", "Mike", "Sam"]
        
        // Cloning into the array first 3 elements
        string[] partOfPeople = new string[3];  // ["Eugene", "Tom", "Mike"]
        people.CopyTo(0, partOfPeople, 0, 3);
        foreach(var person in partOfPeople)
            Console.Write(person + " ");
        Console.WriteLine();
        
        // Position of elements in reverse order
        
        // Reverse all collection
        people.Reverse();   // ["Bob","Sam", "Mike", "Tom", "Eugene"]
        
        var p = people;
        p.Reverse(1, 3);  // ["Eugene","Sam", "Mike", "Tom", "Bob"]
        foreach (var person in p)
            Console.Write(person + " ");
        Console.WriteLine();
        Console.WriteLine();
        // ===== LINKEDLIST<T> =====
        
        var employees2 = new List<string>() { "Tom", "Sam", "Bob" };
        LinkedList<string> people2 = new LinkedList<string>(employees2);
        foreach (var person in people2)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine();

        Console.WriteLine(people2.Count);
        Console.WriteLine(people2.First?.Value);
        Console.WriteLine(people2.Last?.Value);

        Console.WriteLine();
        
        var currentNode = people2.First;
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }
        
        Console.WriteLine();
        
        currentNode = people2.Last;
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Previous;
        }
        Console.WriteLine();
        
        // Using LinkedList methods
        var people3 = new LinkedList<string>();
        people3.AddLast("Tom");
        people3.AddFirst("Bob");
        
        if (people3.First != null) people3.AddAfter(people3.First, "Mike");
        
        foreach(var person in people3) Console.WriteLine(person);
        Console.WriteLine();
        
        // With another types
        var company = new LinkedList<Person>();

        company.AddLast(new Person("Tom"));
        company.AddLast(new Person("Sam"));
        company.AddLast(new Person("Bill"));

        foreach (var person in company) Console.WriteLine(person.Name);
        Console.WriteLine();
        
        // ====== QUEUE<T> ======
        
        Queue<string> queue = new Queue<string>();
        Queue<string> queue2 = new Queue<string>(16);
        
        var employees3 = new List<string> { "Tom", "Sam", "Bob" };
        Queue<string> people4 = new Queue<string>(employees3);
        foreach (var person in people4) Console.WriteLine(person);
        Console.WriteLine(people4.Count);
        Console.WriteLine();
        
        // Using Queue methods
        var people5 = new Queue<string>();
        
        // Add elements
        people5.Enqueue("Tom");
        people5.Enqueue("Bob");
        people5.Enqueue("Sam");
        
        // Getting element from the first queue
        var firstPerson = people5.Peek();
        Console.WriteLine(firstPerson);
        Console.WriteLine();
        
        // Deleting elements
        var person1 = people5.Dequeue();
        Console.WriteLine(person1);
        var person2 = people5.Dequeue();
        Console.WriteLine(person2);
        var person3 = people5.Dequeue();
        Console.WriteLine(person3);

        if (people5.Count > 0)
        {
            var person = people5.Peek();
            people5.Dequeue();
        }
        people5.Clear();
        
        // Add elements
        people5.Enqueue("Tom");

        // Removing elements
        var success1 = people5.TryDequeue(out var person4);  // success1 = true
        if (success1) Console.WriteLine(person4);
        
        var success2 = people5.TryPeek(out var person5);  // success2 = false
        if (success2) Console.WriteLine(person5);
        Console.WriteLine();
        
        // Usage of Queue<T>
        var patients = new Queue<Person>();
        patients.Enqueue(new Person("Tom"));
        patients.Enqueue(new Person("Bob"));
        patients.Enqueue(new Person("Sam"));

        var practitioner = new Doctor();
        practitioner.TakePatients(patients);
        Console.WriteLine();
        
        
        // ======= Stack<T> =======
        Stack<string> stack = new Stack<string>();
        Stack<string> stack2 = new Stack<string>(16);
        
        var employees4 = new List<string>() { "Tom", "Sam", "Bob" };
        Stack<string> people6 = new Stack<string>(employees4);
        foreach (var person in people6) Console.WriteLine(person);

        Console.WriteLine(people6.Count);
        Console.WriteLine();
        
        
        // Using Stack<T> methods
        var people7 = new Stack<string>();
        
        // Add elements
        people7.Push("Tom");
        people7.Push("Sam");
        people7.Push("Bob");
        
        // Getting first element from stack without removing
        string headPerson = people7.Peek();
        Console.WriteLine(headPerson);
        
        string person6 = people7.Pop();
        Console.WriteLine(person6);
        
        string person7 = people7.Pop();
        Console.WriteLine(person7);
        
        string person8 = people7.Pop();
        Console.WriteLine(person8);

        Console.WriteLine();
        
        if(people7.Count > 0)
        {
            var person9 = people7.Peek();
            people7.Pop();
        }
        Console.WriteLine();
        
        var people8 = new Stack<string>();
        people8.Push("Tom");
        
        var success3 = people8.TryPeek(out var person10);  // success3 = true
        if (success3) Console.WriteLine(person10);  // Tom
        
        var success4 = people8.TryPeek(out var person11);  // success = false
        if (success4) Console.WriteLine(person11);
        Console.WriteLine();
        
        // ======== Dictionary<K, V> ========
        
        var people67 = new Dictionary<int, string>()
        {
            { 5, "Tom" },
            { 3, "Sam" },
            { 11, "Bob" }
            
            // [5] = "Tom",
            // [3] = "Sam",
            // [11] = "Bob"
        };
        
        var mike = new KeyValuePair<int, string>(56, "Mike");
        var employees5 = new List<KeyValuePair<int, string>>() { mike };
        var people69 = new Dictionary<int, string>(employees5)
        {
            [5] = "Tom",
            [6] = "Sam",
            [7] = "Bob",
        };
        
        foreach (var person in people69) Console.WriteLine($"Key: {person.Key}, Value: {person.Value}");
        Console.WriteLine();
        foreach (var (key, value) in people69) Console.WriteLine($"Key: {key}, Value: {value}");

        // Dictionary<T> methods
        var phoneBook = new Dictionary<string, string>();
        
        // Add element: key - phone number, value - abonent's name
        phoneBook.Add("+123456", "Tom");
        
        // Checking
        var phoneExists1 = phoneBook.ContainsKey("+123456");
        Console.WriteLine($"+123456: {phoneExists1}");
        var phoneExists2 = phoneBook.ContainsKey("+567456");
        Console.WriteLine($"+567456: {phoneExists2}");
        var abonentExists1 = phoneBook.ContainsValue("Tom");
        Console.WriteLine($"Tom: {abonentExists1}");
        var abonentExists2 = phoneBook.ContainsValue("Bob");
        Console.WriteLine($"Bob: {abonentExists2}");
        
        // Removing element
        phoneBook.Remove("+123456");
        // Checking the count of elements after deletion
        Console.WriteLine($"Count: {phoneBook.Count}");
        Console.WriteLine();
        
        // ======== Class ObservableCollection ========

        ObservableCollection<string> observable = new ObservableCollection<string>();
        
        var observable1 = new ObservableCollection<string>(new string[] { "Tom", "Sam", "Bob" });

        var observable2 = new ObservableCollection<string>()
        {
            "Tom", "Sam", "Bob"
        };

        Console.WriteLine(observable1[0]);
        observable1[0] = "Tomas";
        Console.WriteLine(observable1[0]);
        Console.WriteLine();
        
        foreach (var person in observable1) Console.WriteLine(person);

        Console.WriteLine();
        
        for(int i = 0; i < observable1.Count; i++) Console.WriteLine(observable1[i]);
        
        // Using ObservableCollection<T> Methods
        var people77 = new ObservableCollection<string>();
        
        // add element
        people77.Add("Bob");
        // insert element to index 0
        people77.Insert(0, "Tom");
        
        // checking elements
        bool bobExists = people77.Contains("Bob");
        Console.WriteLine($"Bob exists: {bobExists}");
        bool mikeExists = people77.Contains("Mike");
        Console.WriteLine($"Mike exists: {mikeExists}");
        
        // Remove elements
        people77.Remove("Bob");
        people77.RemoveAt(0);
    }
}

class Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}

class Doctor
{
    public void TakePatients(Queue<Person> patients)
    {
        while (patients.Count > 0)
        {
            var patient = patients.Dequeue();
            Console.WriteLine($"Осмотр пациента: {patient.Name}");
        }
        Console.WriteLine("Доктор закончил осматривать пациентов");
    }
}