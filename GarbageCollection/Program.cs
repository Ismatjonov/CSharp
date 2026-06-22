namespace GarbageCollection;

class Program
{
    static void Main(string[] args)
    {
        Test();
        
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

public class SomeClass : IDisposable
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

public class Derived : SomeClass
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