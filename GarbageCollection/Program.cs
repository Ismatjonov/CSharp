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