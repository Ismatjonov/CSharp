using System.Data.Common;
using System.Text;

namespace FileSystem;

class Program
{
    static async Task Main(string[] args)
    {
        /*DriveInfo[] drives = DriveInfo.GetDrives();

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
        string dirName = @"C:\Users\HOME\RiderProjects\Exercises\Exercises\bin\Debug\net9.0";

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
        
        Console.WriteLine("\nFILTERING");
        // ---- Filtering folders and files
        string[] _dirs = Directory.GetDirectories(dirName, "books*.");
        
        var directory = new DirectoryInfo(dirName);
        DirectoryInfo[] dirrs = directory.GetDirectories("books*.");
        // getting all files started with books
        
        string[] _files = Directory.GetFiles(dirName, "*.exe");
        
        var _directory = new DirectoryInfo(dirName);
        FileInfo[] files_ = _directory.GetFiles("*.exe");

        foreach (var file in files_)
        {
            Console.WriteLine(file.Name);
        }
        
        // ---- Creating some dir ----
        // string path = @"C:\SomeDir";
        // string subpath = @"program\avalon";
        // DirectoryInfo dirInfo = new DirectoryInfo(path);
        // if (!dirInfo.Exists)
        // {
        //     dirInfo.Create();
        // }
        // dirInfo.CreateSubdirectory(subpath);
        // Console.WriteLine();
        
        // ---- getting information about dir ----
        string dName = @"C:\Program Files";
        
        DirectoryInfo dinfo = new DirectoryInfo(dName);

        Console.WriteLine($"Dir name: {dName}");
        Console.WriteLine($"Full dir name: {dinfo.FullName}");
        Console.WriteLine($"Creation time: {dinfo.CreationTime}");
        Console.WriteLine($"Root directory: {dinfo.Root}");

        Console.WriteLine();
        
        // ---- Deleting ----
        /*string directName = @"C:\SomeDir";
        if (Directory.Exists(directName))
        {
            Directory.Delete(directName);
            Console.WriteLine("Directory deleted");
        }
        else
        {
            Console.WriteLine("Directory is not exists");
        }#1#
        
        // ---- Moving a directory ----
        string oldPath = @"C:\SomeFolder";
        string newPath = @"C:\SomeDir";
        Directory.CreateDirectory(oldPath);
        DirectoryInfo directoryInfo = new DirectoryInfo(oldPath);
        if (directoryInfo.Exists && !Directory.Exists(newPath))
        {
            directoryInfo.MoveTo(newPath);
            // or like this
            // Directory.Move(oldPath, newPath);
        }

        Console.WriteLine();*/
        
        // ========== Working with files. Class File & FileInfo ==========
        
        // ---- getting info from files ----
        /*string PATH = @"C:\Users\Home\Documents\content.txt";
        FileInfo fileInfo = new FileInfo(PATH);
        
        if (fileInfo.Exists)
        {
            Console.WriteLine($"File name: {fileInfo.Name}");
            Console.WriteLine($"Creation date: {fileInfo.CreationTime}");
            Console.WriteLine($"File size: {fileInfo.Length}");
        }

        Console.WriteLine();
        // ---- deleting a file ----
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
            Console.WriteLine("File has been deleted");
        }*/
        
        // ---- Moving a file ----
        /*string oldPath = @"C:\OldDir\content.txt";
        string newPath = @"C:\NewDir\index.txt";
        FileInfo fileInf = new FileInfo(oldPath);
        if (fileInf.Exists)
        {
            fileInf.MoveTo(newPath, true);
            // or like this, using class 'File'
            // File.Move(oldPath, newPath);
        }*/
        
        // ---- Coping file ----
        /*string oldPath = @"C:\OldDir\content.txt";
        string newPath = @"C:\NewDir\index2.txt";
        FileInfo fileInfo = new FileInfo(oldPath);
        if (fileInfo.Exists)
        {
            fileInfo.CopyTo(newPath, true);
        }*/
        
        // ----- Reading and recording files -----
        string path = @"C:\app\content.txt";

        string originalText = "Hello Metanit.com";
        
        await File.WriteAllTextAsync(path, originalText, Encoding.GetEncoding("iso-8859-1"));
        
        await File.AppendAllTextAsync(path, "\nHello code.", Encoding.GetEncoding("iso-8859-1"));

        string fileText = await File.ReadAllTextAsync(path, Encoding.GetEncoding("iso-8859-1"));
        Console.WriteLine(fileText);
        Console.WriteLine();
    }
}