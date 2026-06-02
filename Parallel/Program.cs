using System.Threading.Channels;
using System.Threading.Tasks;

namespace Parallelism;

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
        //     var outer = Task.Factory.StartNew(() =>
        //     {
        //         Console.WriteLine("Outer task starting...");
        //         var inner = Task.Factory.StartNew(() =>
        //         {
        //             Console.WriteLine("Inner task starting...");
        //             Thread.Sleep(2000);
        //             Console.WriteLine("Inner task finished.");
        //         }, TaskCreationOptions.AttachedToParent);
        //     });
        //     outer.Wait();
        //     Console.WriteLine("End of Main");
        // }

        // Task[] tasks1 = new Task[3]
        // {
        //     new Task(() => Console.WriteLine("First Task")),
        //     new Task(() => Console.WriteLine("Second Task")),
        //     new Task(() => Console.WriteLine("Third Task"))
        // };
        // foreach (var t in tasks1)
        //     t.Start();
        //
        // Task[] tasks2 = new Task[3];
        // int j = 1;
        // for(int i = 0; i < tasks2.Length; i++)
        //     tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine("Task " + j++));

        // Task[] tasks = new Task[3];
        // for (var i = 0; i < tasks.Length; i++)
        // {
        //     tasks[i] = new Task(() =>
        //     {
        //         Thread.Sleep(1000);
        //         Console.WriteLine($"Task{i} finished");
        //     });
        //     tasks[i].Start();
        // }
        // Console.WriteLine("End of Main");
        // Task.WaitAll(tasks);
        //
        
        // // returning results from tasks
        // int n1 = 4, n2 = 5;
        // Task<int> sumTask = new Task<int>(() => Sum(n1, n2));
        // sumTask.Start();
        //
        // int result = sumTask.Result;
        // Console.WriteLine($"{n1} + {n2} = {result}");
        //
        // int Sum(int a, int b) => a + b;

        // Task<Person> defaultPersonTask = new Task<Person>(() => new Person("Tom", 37));
        // defaultPersonTask.Start();
        //
        // Person defaultPerson = defaultPersonTask.Result;
        // Console.WriteLine($"{defaultPerson.Name} - {defaultPerson.Age}");
        
        // ======== Continuation Task ========
        // Task task1 = new Task(() =>
        // {
        //     Console.WriteLine($"Task Id: {Task.CurrentId}");
        // });
        //
        // Task task2 = task1.ContinueWith(PrintTask);
        //
        // task1.Start();
        // task2.Wait();
        //
        // Console.WriteLine("End of Main!");
        //
        // void PrintTask(Task t)
        // {
        //     Console.WriteLine($"Task Id: {Task.CurrentId}");
        //     Console.WriteLine($"Previous Task Id: {t.Id}");
        //     Thread.Sleep(3000);
        // }

        // Task<int> sumTask = new Task<int>(() => Sum(4, 5));
        //
        // Task printTask = sumTask.ContinueWith(task => PrintResult(task.Result));
        // sumTask.Start();
        //
        // printTask.Wait();
        // Console.WriteLine("End of Main!");
        //
        // int Sum(int a, int b) => a + b;
        //
        // void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");
        //
        // // task chain
        // Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));
        //
        // Task task2 = task1.ContinueWith(t => 
        //     Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
        //
        // Task task3 = task2.ContinueWith(t => 
        //     Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
        //
        // Task task4 = task3.ContinueWith(t => 
        //     Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
        //
        // task1.Start();
        //
        // task4.Wait();
        //
        // Console.WriteLine("End of Main!");
        
        // ========== class Parallel ==========
        // Parallel.Invoke(
        //     Print,
        //     () =>
        //     {
        //         Console.WriteLine($"Executing task: {Task.CurrentId}");
        //         Thread.Sleep(3000);
        //     },
        //     () => Square(5)
        //     );
        //
        // void Print()
        // {
        //     Console.WriteLine($"Executing task: {Task.CurrentId}");
        //     Thread.Sleep(3000);
        // }

        void Square(int n)
        {
            Console.WriteLine($"Executing task: {Task.CurrentId}");
            Console.WriteLine($"Square of number {n} is equals {n * n}");
            Thread.Sleep(3000);
        }

        Parallel.For(1, 5, Square);
    }
}
record class Person(string Name, int Age);