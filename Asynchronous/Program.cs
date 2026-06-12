namespace Asynchronous;

class Program
{
    static async Task Main(string[] args)
    {
        // await PrintAsync();
        // Console.WriteLine("Some action in method Main");
        //
        // void Print()
        // {
        //     Thread.Sleep(3000);
        //     Console.WriteLine("Hello METANIT.COM");
        // }
        //
        // async Task PrintAsync()
        // {
        //     Console.WriteLine("Start PrintAsync");
        //     await Task.Run(Print);
        //     Console.WriteLine("End PrintAsync");
        // }
        
        // -- Delay asynchronous operations and Task.Delay
        // await PrintAsync();
        // Console.WriteLine("Some actions in method Main");
        //
        // async Task PrintAsync()
        // {
        //     await Task.Delay(3000);
        //     // or like this
        //     // await Task.Delay(TimeSpan.FromSeconds(3));
        //     Console.WriteLine("Hello Metanit.com");
        // }

        // Benefits of asynchronous
        await PrintNameAsync("Tom");
        await PrintNameAsync("Bob");
        await PrintNameAsync("Sam");
        async Task PrintNameAsync(string name)
        {
            await Task.Delay(3000);
            Console.WriteLine(name);
        }
    }
}