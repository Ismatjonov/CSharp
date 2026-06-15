using System.Formats.Asn1;

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
        // Account account = new Account();
        // account.Added += PrintAsync;
        //
        // account.Put(500);
        //
        // await Task.Delay(2000);
        //
        // async void PrintAsync(object sender, string message)
        // {
        //     await Task.Delay(1000);
        //     Console.WriteLine(message);
        // }
        
        // -- Task
        // await PrintAsync("Hello Metanit.com");
        //
        // async Task PrintAsync(string message)
        // {
        //     await Task.Delay(1000);
        //     Console.WriteLine(message);
        // }
        
        // another way
        // var task = PrintAsync("Hello Metanit.com");
        // Console.WriteLine("Main works");
        //
        // await task;
        //
        // async Task PrintAsync(string message)
        // {
        //     await Task.Delay(1000);
        //     Console.WriteLine(message);
        // }
        
        // -- Task<T>
        // int n1 = await SquareAsync(5);
        // int n2 = await SquareAsync(6);
        // Console.WriteLine($"n1={n1}  n2={n2}");
        // async Task<int> SquareAsync(int n)
        // {
        //     await Task.Delay(0);
        //     return n * n;
        // }
        //
        // Person person = await GetPersonAsync("Tom");
        // Console.WriteLine(person.Name);
        //
        // Console.WriteLine("Other actions in method Main");
        //
        // async Task<Person> GetPersonAsync(string name)
        // {
        //     await Task.Delay(0);
        //     return new Person(name);
        // }
        
        // -- Example --
        // var square5 = SquareAsync(5);
        // var square6 = SquareAsync(6);
        //
        // Console.WriteLine("Other actions in method Main");
        //
        // int n1 = await square5;
        // int n2 = await square6;
        // Console.WriteLine($"n1={n1}, n2={n2}");
        //
        // async Task<int> SquareAsync(int n)
        // {
        //     await Task.Delay(0);
        //     var result =  n * n;
        //     Console.WriteLine($"The square of number {n} is {n * n}");
        //     return result;
        // }
        
        // -- ValueTask<T> --
        // var result = await AddAsync(4, 5);
        // Console.WriteLine(result);
        //
        // Task<int> AddAsync(int a, int b)
        // {
        //     return Task.FromResult(a + b);
        // }    // Extra memory allocation
        
        // var result = await AddAsync(4, 5);
        // Console.WriteLine(result);
        //
        // ValueTask<int> AddAsync(int x, int y)
        // {
        //     return new ValueTask<int>(x + y);
        // }    // correct solution!
        
        // -- we can also cast ValueTask to Task
        // var getMessage = GetMessageAsnc();
        // string message = await getMessage.AsTask();
        // Console.WriteLine(message);
        //
        // async ValueTask<string> GetMessageAsnc()
        // {
        //     await Task.Delay(0);
        //     return "Hello";
        // }
        
        // ========== Sequential and parallel execution ==========
        // var task1 = PrintAsync("Hello C#");
        // var task2 =  PrintAsync("Hello World");
        // var task3 = PrintAsync("Hello Metanit.com");
        //
        // // await Task.WhenAny(task1, task2, task3);
        // await Task.WhenAll(task1, task2, task3);
        // async Task PrintAsync(string message)
        // {
        //     await Task.Delay(2000);
        //     Console.WriteLine(message);
        // }
        
        // -- Getting the result
        // ** Task.WhenAll() **
        var task1 = SquareAsync(4);
        var task2 = SquareAsync(5);
        var task3 = SquareAsync(6);
        
        int[] results = await Task.WhenAll(task1, task2, task3);

        foreach (int result in results)
        {
            Console.WriteLine(result);
        }
        async Task<int> SquareAsync(int n)
        {
            await Task.Delay(1000);
            return n * n;
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

record class Person(string Name);