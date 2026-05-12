using System.Threading;

namespace Threading;

class Program
{
    static void Main(string[] args)
    {
        // Getting current thread
        Thread currentThread = Thread.CurrentThread;
        
        // getting thread's name
        Console.WriteLine($"Имя потока: {currentThread.Name}");
        currentThread.Name = "Метод Main";
        Console.WriteLine($"Имя потока: {currentThread.Name}");

        Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
        Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
        Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
        Console.WriteLine($"Статус потока: {currentThread.ThreadState}");
        Console.WriteLine();
        
        // use method Sleep()
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);  // delay execution by 500 milliseconds
            Console.WriteLine(i);
        }
        Console.WriteLine();
        
    }
}