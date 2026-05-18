using System.Threading;
using System.Threading.Channels;

namespace Threading;

class Program
{
    static void Main(string[] args)
    {
        // // Getting current thread
        // Thread currentThread = Thread.CurrentThread;
        //
        // // getting thread's name
        // Console.WriteLine($"Имя потока: {currentThread.Name}");
        // currentThread.Name = "Метод Main";
        // Console.WriteLine($"Имя потока: {currentThread.Name}");
        //
        // Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
        // Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
        // Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
        // Console.WriteLine($"Статус потока: {currentThread.ThreadState}");
        // Console.WriteLine();
        //
        // // use method Sleep()
        // for (int i = 0; i < 10; i++)
        // {
        //     Thread.Sleep(500); // delay execution by 500 milliseconds
        //     Console.WriteLine(i);
        // }
        //
        // Console.WriteLine();
        //
        // // ======== Creating threads. Delegate ThreadStart ========
        // Thread myThreads1 = new Thread(Print);
        // Thread myThreads2 = new Thread(new ThreadStart(Print));
        // Thread myThreads3 = new Thread(() => Console.WriteLine("Hello Threads"));
        //
        // myThreads1.Start();
        // myThreads2.Start();
        // myThreads3.Start();
        // void Print() => Console.WriteLine("Hello Threads!");
        // Console.WriteLine();
        //
        // Thread myThread = new Thread(Display);
        // myThread.Start();
        //
        // for (int i = 0; i < 5; i++)
        // {
        //     Console.WriteLine($"Главный поток: {i}");
        //     Thread.Sleep(300);
        // }
        //
        // void Display()
        // {
        //     for (int i = 0; i < 5; i++)
        //     {
        //         Console.WriteLine($"Второй поток: {i}");
        //         Thread.Sleep(400);
        //     }
        // }
        // Console.WriteLine();
        //
        //
        // // ======== Threads with ParameterizedThreadStart ========
        //
        // // Creating new threads
        // Thread mt1 = new Thread(new ParameterizedThreadStart(Show));
        // Thread mt2 = new Thread(Show);
        // Thread mt3 = new Thread(message => Console.WriteLine(message));
        //
        // // Run threads
        // mt1.Start("Hello!");
        // mt2.Start("Привет!");
        // mt3.Start("Салом!");
        //
        //
        // void Show(object? message) => Console.WriteLine(message);

        /*
         int number = 4;
         Thread myThread = new Thread(Print);
         myThread.Start(number);

         void Print(object? obj)
         {
             if (obj is int n)
             {
                 Console.WriteLine($"n * n = {n * n}");
             }
         }
         */

        /*
        Person tom = new Person("Tom", 37);
        Thread myThread = new Thread(Print);
        myThread.Start(tom);

        void Print(object obj)
        {
            if (obj is Person person)
            {
                Console.WriteLine($"Name = {person.Name}");
                Console.WriteLine($"Age = {person.Age}");
            }
        }
        */

        // Person tom = new Person("Tom", 37);
        // Thread myThread = new Thread(tom.Print);
        // myThread.Start();

        // ======== Thread Synchronization ========
        // Running test thread
        /*
        int x = 0;

        // run 5 threads
        for (int i = 0; i < 6; i++)
        {
            Thread myThread = new(Print);
            myThread.Name = $"Thread {i}";
            myThread.Start();
        }
        void Print()
        {
            x = 1;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(500);
            }
        }
        */

        // Synchronizing threads
        /*
        int x = 0;
        object locker = new(); // lock-object
        for (int i = 0; i < 6; i++)
        {
            Thread myThread = new Thread(Print);
            myThread.Name = $"Thread {i}";
            myThread.Start();
        }
        void Print()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
        */

        // ======== Monitors ========
        /*
        int x = 0;
        object locker = new object();
        for (int i = 0; i < 6; i++)
        {
            Thread myThread = new Thread(Print);
            myThread.Name = "Thread " + i;
            myThread.Start();
        }
        void Print()
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                x = 1;
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {x++}");
                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if(acquiredLock) Monitor.Exit(locker);
            }
        }
        */

        // ======== Class Lock & Synchronization ========
        /* Class Lock
        int x = 0; // some common resource
        Lock _lockobj = new();

        for (int i = 0; i < 6; i++)
        {
            Thread myThread = new Thread(Print);
            myThread.Name = $"Thread {i}";
            myThread.Start();
        }

        void Print()
        {
            lock (_lockobj)
            {
                x = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x++}");
                    Thread.Sleep(100);
                }
            }
        }
        */

        // methhod Enter()
        // int x = 0; // some common resource
        // Lock _lockobj = new();
        //
        // for (int i = 0; i < 6; i++)
        // {
        //     Thread myThread = new Thread(Print);
        //     myThread.Name = $"Thread {i}";
        //     myThread.Start();
        // }

        // method Enter()
        /*void Print()
        {
            _lockobj.Enter();
            try
            {
                x = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x++}");
                    Thread.Sleep(100);
                }
            }
            finally
            {
                _lockobj.Exit();
                Console.WriteLine();
            }
        }*/

        // method TryEnter()
        // void Print()
        // {
        //     if (_lockobj.TryEnter())
        //     {
        //         try
        //         {
        //             x = 1;
        //             for (int i = 0; i < 6; i++)
        //             {
        //                 Console.WriteLine($"{Thread.CurrentThread.Name}: {x++}");
        //                 Thread.Sleep(100);
        //             }
        //         }
        //         finally
        //         {
        //             _lockobj.Exit();
        //         }
        //     }
        // }

        // method EnterScope()
        // void Print()
        // {
        //     using (_lockobj.EnterScope())
        //     {
        //         x = 1;
        //         for (int i = 0; i < 6; i++)
        //         {
        //             Console.WriteLine($"{Thread.CurrentThread.Name}: {x++}");
        //             Thread.Sleep(100);
        //         }
        //     }
        // }
        
        // ======== Class AutoResetEvent ========
        // int x = 0;  // Common resource
        //
        // AutoResetEvent waitHandler = new AutoResetEvent(true);  // event-object
        //
        // // Running five threads
        // for (int i = 0; i < 6; i++)
        // {
        //     Thread myThread = new Thread(Print);
        //     myThread.Name = "Thread " + i;
        //     myThread.Start();
        // }
        //
        // void Print()
        // {
        //     // waitHandler.WaitOne();  // Waiting for signal
        //     AutoResetEvent.WaitAll(new WaitHandle[] { waitHandler });   // if we use few objects of AutoResetEvent
        //     x = 1;
        //     for (int i = 0; i < 6; i++)
        //     {
        //         Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        //         x++;
        //         Thread.Sleep(100);
        //     }
        //     waitHandler.Set();  // Signal that waitHandler is in the signaled state
        // }
        
        // ======== Mutex ========
        int x = 0;
        Mutex mutexObj = new Mutex();
        
        // Running five threads
        for (int i = 0; i < 6; i++)
        {
            Thread myThread = new Thread(Print);
            myThread.Name = "Thread " + i;
            myThread.Start();
        }

        void Print()
        {
            mutexObj.WaitOne(); // suspend the thread until a mutex is acquired
            x = 1;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex(); // release the mutex
        }
    }
}

record class Person(string Name, int Age)
{
    public void Print()
    {
        Console.WriteLine($"Name = {Name}");
        Console.WriteLine($"Age = {Age}");
    }
}