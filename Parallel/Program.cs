using System.Threading.Channels;

namespace Parallel;

class Program
{
    static void Main(string[] args)
    {
        Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
        task1.Start();
        
        Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));
        
        Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

        task1.Wait();
        task2.Wait();
        task3.Wait();
        
        // 
        Console.WriteLine("MAin Starts");

        Task task = new Task(() =>
        {
            Console.WriteLine("Task Starts");
            Thread.Sleep(1000);
            Console.WriteLine("Task Ends");
        });
        task.RunSynchronously();
        Console.WriteLine("Main Ends");
    }
}