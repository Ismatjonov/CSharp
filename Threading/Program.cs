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
        
        // ======== Creating threads. Delegate ThreadStart ========
        Thread myThreads1 = new Thread(Print);
        Thread myThreads2 = new Thread(new ThreadStart(Print));
        Thread myThreads3 = new Thread(() => Console.WriteLine("Hello Threads"));

        myThreads1.Start();
        myThreads2.Start();
        myThreads3.Start();
        void Print() => Console.WriteLine("Hello Threads!");
        Console.WriteLine();

        Thread myThread = new Thread(Display);
        myThread.Start();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Главный поток: {i}");
            Thread.Sleep(300);
        }
        void Display()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Второй поток: {i}");
                Thread.Sleep(400);
            }
        }
    }
}