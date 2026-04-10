namespace CSharp;

public partial class Person
{
    public partial string Name { get; set; }
    public void Move() => Console.WriteLine("Man is moving!");
    public partial void Say(string message);
    // Они не могут иметь модификаторы доступа
    // Они не могут иметь out-параметры
    // Они иметь тип void
    // Они не могут иметь модификаторы virtual, override, sealed, new или extern
}