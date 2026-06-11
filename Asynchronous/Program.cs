namespace Asynchronous;

class Program
{
    static async Task Main(string[] args)
    {
        await PrintAsync();
        Console.WriteLine("Some action in method Main");

        void Print()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Hello METANIT.COM");
        }

        async Task PrintAsync()
        {
            Console.WriteLine("Start PrintAsync");
            await Task.Run(Print);
            Console.WriteLine("End PrintAsync");
        }
    }
}