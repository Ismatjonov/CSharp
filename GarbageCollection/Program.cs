using System.Net.Quic;

namespace GarbageCollection;

class Program
{
    static void Main(string[] args)
    {
        /*Test();
        
        void Test()
        {
            Person tom = new Person("Tom");
            Console.WriteLine(tom.Name);
        }
        
        // ---- class System.GC ----
        
        long totalMemory = GC.GetTotalMemory(false);
        
        GC.Collect(0, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        Console.WriteLine();
        
        // ========== Finalizable objects ==========
        Test();
        GC.Collect();
        Console.Read();
        Console.WriteLine();

        // ---- IDisposable ----
        Test2();
        void Test2()
        {
            Person? tom = null;
            try
            {
                tom = new Person("Tom");
            }
            finally
            {
                tom?.Dispose();
            }
        }
        Console.WriteLine();
        // ========== Construction using ==========
        Test3();

        void Test3()
        {
            using Person tom = new Person("Tom") ;
                // tom is available only in block using
                // some actions with object Person
                Console.WriteLine($"Name: {tom.Name}");
                Console.WriteLine("End of Test");
        }
        
        // ---- Freeing up a lot of resources ----
        Test4();
        void Test4()
        {
            using Person tom = new Person("Tom");
            using Person bob = new Person("Bob");
            Console.WriteLine($"Person 1: {tom.Name}, Person 2: {tom.Name}");
            Console.WriteLine("End of method Test");
        }
        
        // --- Another Examole ----
        
        // creating connection
        // using var con = new Connection();
        // con.Open(new Socket()); // opening conditional socket for network interactions
        
        
        // ---- Abstracting the completion of using ----
        var con = new Connection();

        using var closeSocket = new Connection.ScopeExit(() =>
        {
            con.Close();
            Console.WriteLine("Socket is free");
        });
        
        con.Open(new Socket());
        Console.WriteLine();*/
        
        // ========== Signposts =========
        unsafe
        {
            int* x;
            int y = 10;

            x = &y;
            Console.WriteLine(*x);
            
            ulong addr = (ulong)x;
            Console.WriteLine($"Address of variable y: {addr}");
        }
        
        // ---- Pointer to another pointer ----
        unsafe
        {
            int* x;
            int y = 10;
            
            x = &y;
            int** z = &x;
            **z = **z + 40;
            Console.WriteLine(y);
            Console.WriteLine(**z);
        }

        unsafe
        {
            Point point = new Point(0, 0);
            Console.WriteLine(point);
            Point* p = &point;

            p->X = 30;
            Console.WriteLine(p->X);

            (*p).Y = 180;
            Console.WriteLine((*p).Y);

            Console.WriteLine(point);

        }

        unsafe
        {
            const int size = 7;
            int* square = stackalloc int[size];
            int* p = square;

            for (int i = 1; i <= size; i++, p++)
            {
                *p = i * i;
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(square[i]);
            }
        }

        unsafe
        {
            const int size = 7;
            int* factorial = stackalloc int[size];
            int* p = factorial;

            *(p++) = 1;

            for (int i = 1; i <= size; i++, p++)
            {
                *p = p[-1] * i;
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(factorial[i]);
            }
        }

        unsafe
        {
            Pointer pointer = new Pointer();
            fixed (int* pX = &pointer.x)
            {
                *pX = 30;
            }
            fixed (int* pY = &pointer.y)
            {
                *pY = 150;
            }

            Console.WriteLine(pointer);
        }

        unsafe
        {
            int[] numbers = { 0, 1, 2, 3, 8, 77 };
            string str = "Hello World!";
            fixed (int* p = numbers)
            {
                int third = *(p + 2);
                Console.WriteLine(third);
            }

            fixed (char* p = str)
            {
                char forth = *(p + 3);
                Console.WriteLine(forth);
            }
        }
        
    }
}

class Person : IDisposable
{
    public string Name { get; set; }
    public Person(string name) => Name = name;

    public void Dispose()
    {
        Console.WriteLine($"{Name} has been disposed");
    }
}

class SomeClass : IDisposable
{
    private bool disposed = false;
    
    // implement interface IDisposable.
    public void Dispose()
    {
        // free up uncontrollable resource
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            // free up controllable resources
        }
        disposed = true;
    }
    
    // Destructor
    ~SomeClass()
    {
        Dispose(false);
    }
}

class Derived : SomeClass
{
    private bool IsDisposed = false;
 
    protected override void Dispose(bool disposing)
    {
        if (IsDisposed) return;
        if (disposing)
        {
            // Освобождение управляемых ресурсов
        }
        IsDisposed = true;
        // Обращение к методу Dispose базового класса
        base.Dispose(disposing);
    }
}

// class Socket
class Socket
{
    public bool IsOpened { get; set; }  // is socket open
}

// class of net connection
class Connection
{
    Socket? activeSocket = null;

    public void Open(Socket? socket)
    {
        if (activeSocket != socket) // checking socket
        {
            Close();    // close socket if another socket has been set recently
            activeSocket = socket;
            if (activeSocket != null) activeSocket.IsOpened = true;
            Console.WriteLine("Connection opened. Available to send packages via net");
        }
    }
    // closing socket
    public void Close()
    {
        if (activeSocket is not null)
        {
            activeSocket.IsOpened = false;
            Console.WriteLine("Connection closed...");
        }
    }
    public ref struct ScopeExit
    {
        public ScopeExit(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            action.Invoke();
        }
        
        Action action;
    }
}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()=> $"X: {X}, Y: {Y}";
}

class Pointer
{
    public int x;
    public int y;
    public override string ToString()=> $"X: {x}, Y: {y}";
}