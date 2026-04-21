using System;
using System.Collections.Generic;
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
        
        var people2 = people;
        people2.Reverse(1, 3);  // ["Eugene","Sam", "Mike", "Tom", "Bob"]
        foreach (var person in people2)
            Console.Write(person + " ");
        Console.WriteLine();
    }
}

class Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}