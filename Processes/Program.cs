using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

namespace Processes;

class Program
{
    static void Main(string[] args)
    {
        /*var proceess = Process.GetCurrentProcess();
        Console.WriteLine($"Id: {proceess.Id}");
        Console.WriteLine($"Name: {proceess.ProcessName}");
        Console.WriteLine($"Virtual Memory: {proceess.VirtualMemorySize64}");
        Console.WriteLine();
        
        // Getting all run processes
        foreach (Process process in Process.GetProcesses())
        {
            // Console.WriteLine($"Id: {process.Id}, Name: {process.ProcessName}");
        }

        Console.WriteLine();
        
        // getting an ID of processes which introduce Rider
        Process[] riderProcesses = Process.GetProcessesByName("telegram");
        foreach(Process riderProcess in riderProcesses)
            Console.WriteLine($"Id: {riderProcess.Id}");
        Console.WriteLine();
        
        // ---- Threads Process ----
        Process proc = Process.GetProcessesByName("rider64")[0];
        ProcessThreadCollection processThread = proc.Threads;
        
        foreach(ProcessThread thread in processThread)
            Console.WriteLine($"ThreadId: {thread.Id}");
        Console.WriteLine();
        
        // ------ Module Processes ------
        ProcessModuleCollection processModules = proc.Modules;
        
        foreach(ProcessModule module in processModules)
            Console.WriteLine($"Name: {module.ModuleName},  FileName: {module.FileName}");
        Console.WriteLine();
        
        // ------ Starting a new processes ------
        // Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
        
        ProcessStartInfo procInfo = new ProcessStartInfo();
        procInfo.FileName = @"C:\Program Files\WindowsApps\TelegramMessengerLLP.TelegramDesktop_6.8.2.0_x64__t4vj0pshhgkwm\Telegram.exe";

        // procInfo.Arguments = "http://bakhtovar-portfolio.web.app";
        Process.Start(procInfo);*/
        
        
        // ==================== Application domains =====================
        /*AppDomain domain = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {domain.FriendlyName}");
        Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
        Console.WriteLine();
        
        Assembly[] assembly = domain.GetAssemblies();
        foreach (Assembly asm in assembly)
        {
            Console.WriteLine(asm.GetName().Name);
        }*/
        
        // ======== AssemblyLoadContext and dynamic assembly loading and unloading =========
        Sqaure(8);
        
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine();

        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            Console.WriteLine(asm.GetName().Name);
        }

        void Sqaure(int number)
        {
            var context = new AssemblyLoadContext(name: "Sqaure", isCollectible: true);
            
            // setting up unloading handle
            context.Unloading += Context_Unloading;
            
            // getting MyApp path
            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\HOME\\RiderProjects\\CSharp\\MyApp\\bin\\Debug\\net10.0\\MyApp.dll");
            
            // loading assembly
            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
            
            // getting type 'Program' from MyApp.dll
            var type = assembly.GetType("MyApp.Program");
            if (type is not null)
            {
                // getting his method Square
                var squareMethod = type.GetMethod("Square", BindingFlags.Static | BindingFlags.NonPublic);
                // invoke method
                var result = squareMethod.Invoke(null, new object[] { number });
                if (result is int)
                {
                    Console.WriteLine($"The result is {result}");
                }
            }
            // watching with assemblies had been uploaded
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);
            context.Unload();
        }

        void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine($"MyApp library has been unloaded");
        }
    }
}