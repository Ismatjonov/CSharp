using System.Diagnostics;
namespace Processes;

class Program
{
    static void Main(string[] args)
    {
        var proceess = Process.GetCurrentProcess();
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
    }
}