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

        // -- Benefits of asynchronous
        // await PrintNameAsync("Tom");
        // await PrintNameAsync("Bob");
        // await PrintNameAsync("Sam");
        // async Task PrintNameAsync(string name)
        // {
        //     await Task.Delay(3000);
        //     Console.WriteLine(name);
        // }
        
        // -- Defining an asynchronous lambda expression
        // Func<string, Task> printer = async (message) =>
        // {
        //     await Task.Delay(2000);
        //     Console.WriteLine(message);
        // };
        //
        // await printer("Hello World!");
        // await printer("Hello METANIT.COM!");
        
        // ========== Returning a result from an asynchronous method ==========
        // PrintAsync("Hello World");
        // PrintAsync("Hello Metanit.com");
        //
        // Console.WriteLine("Main End");
        // await Task.Delay(3000); // waiting fot the task to complete
        //
        // // defining async method
        // async void PrintAsync(string message)
        // {
        //     await Task.Delay(1000);
        //     Console.WriteLine(message);
        // }
        // -- Void: Example
        Account account = new Account();
        account.Added += PrintAsync;
        
        account.Put(500);

        await Task.Delay(2000);

        async void PrintAsync(object sender, string message)
        {
            await Task.Delay(1000);
            Console.WriteLine(message);
        }

    }
}

class Account
{
    private int sum = 0;
    public event EventHandler<string>? Added;

    public void Put(int sum)
    {
        this.sum += sum;
        Added?.Invoke(this, $"The account has been credited ${sum}.");
    }
}