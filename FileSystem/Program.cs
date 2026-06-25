using System.Data.Common;

namespace FileSystem;

class Program
{
    static void Main(string[] args)
    {
        DriveInfo[] drives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine($"Name: {drive.Name}");
            Console.WriteLine($"Type: {drive.DriveType}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Total Size: {drive.TotalSize}");
                Console.WriteLine($"Free Space: {drive.TotalFreeSpace}");
                Console.WriteLine($"Drive label: {drive.VolumeLabel}");
            }
        }

        Console.WriteLine();
        
        // ========== Working with directories ========== 
        string dirName = "C:\\Program Files";

        if (Directory.Exists(dirName))
        {
            Console.WriteLine("Subdirectories: ");
            string[] dirs = Directory.GetDirectories(dirName);
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine("Files: ");
            string[] files = Directory.GetFiles(dirName);
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }
    }
}