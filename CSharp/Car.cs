namespace CSharp;

public record Car(string Name, int Year)
{
    // public string Name { get; init; }
    // public int Year { get; init; }
    //
    // public Car(string name, int year)
    // {
    //     Name = name;
    //     Year = year;
    // }
    public string Color { get; set; } = "";
}

// Используем readonly чтобы не могли исменить значение
public record struct Animal(string Name, int Age);

public class Book
{
    public string Name { get; init; }
    public Book(string name) => Name = name;
}
public record Supercar(string Name, int Year, string Company) : Car(Name, Year);