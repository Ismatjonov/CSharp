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
        {
            buffer[i] = i * i;
        }

        for (var i = 0; i < Buffer.COUNT; i++)
        {
            Console.WriteLine(buffer[i]);
        }
    }
}