using System.Diagnostics;
using System.Reflection;

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
        AppDomain domain = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {domain.FriendlyName}");
        Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
        Console.WriteLine();
        
        Assembly[] assembly = domain.GetAssemblies();
        foreach (Assembly asm in assembly)
        {
            Console.WriteLine(asm.GetName().Name);
        }
    }
}