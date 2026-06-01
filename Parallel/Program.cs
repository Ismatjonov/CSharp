using System.Threading.Channels;

namespace Parallel;

class Program
{
    static void Main(string[] args)
    {
        // Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
        // task1.Start();
        //
        // Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));
        //
        // Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));
        //
        // task1.Wait();
        // task2.Wait();
        // task3.Wait();
        //
        // // Execute synchronously
        // Console.WriteLine("MAin Starts");
        //
        // Task task = new Task(() =>
        // {
        //     Console.WriteLine("Task Starts");
        //     Thread.Sleep(1000);
        //     Console.WriteLine("Task Ends");
        // });
        // task.RunSynchronously();
        // Console.WriteLine("Main Ends");
        
        // Properties of class Task
        // Task tsk = new Task(() =>
        // {
        //     Console.WriteLine($"Task{Task.CurrentId} Starts");
        //     Thread.Sleep(1000);
        //     Console.WriteLine($"Task{Task.CurrentId} Ends");
        // });
        // tsk.Start();
        //
        // Console.WriteLine($"tsk ID: {tsk.Id}");
        // Console.WriteLine($"tsk is Completed: {tsk.IsCompleted}");
        // Console.WriteLine($"tsk Status: {tsk.Status}");
        // tsk.Wait();
        // Console.WriteLine($"tsk is Completed: {tsk.IsCompleted}");
        
        // ======== Working with class Task ========
        var outer = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task starting...");
            var inner = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Inner task starting...");
                Thread.Sleep(2000);
                Console.WriteLine("Inner task finished.");
            }, TaskCreationOptions.AttachedToParent);
        });
        outer.Wait();
        Console.WriteLine("End of Main");
    }
}