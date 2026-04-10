namespace CSharp;

class Program
{
    static void Main(string[] args)
    {
        var tom = new Person("Tom");
        tom.Eat();
        tom.Move();
        tom.Say("Hello, I'm Tom!");
    }
}