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
        /*string path = @"C:\app\content.txt";

        string originalText = "Hello Metanit.com";
        
        await File.WriteAllTextAsync(path, originalText, Encoding.GetEncoding("iso-8859-1"));
        
        await File.AppendAllTextAsync(path, "\nHello code.", Encoding.GetEncoding("iso-8859-1"));

        string fileText = await File.ReadAllTextAsync(path, Encoding.GetEncoding("iso-8859-1"));
        Console.WriteLine(fileText);
        Console.WriteLine();*/
        
        // ========== FileStream. Reading and recording files ==========

        /*FileStream? fstream = null;
        try
        {
            fstream = new FileStream("note3.dat", FileMode.OpenOrCreate);
            // operation with fstream
        }
        catch (Exception ex)
        {
        }
        finally
        {
            fstream?.Close();
        }*/
        
        // ---- reading and recording files ----
        /*string path = @"C:\app\note.txt";
        string text = "Hello, Metanit.com";
        
        // record
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            await fs.WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Text has been written to file.");
        }
        
        // reading
        using (FileStream fs = File.OpenRead(path))
        {
            byte[] buffer = new byte[fs.Length];
            await fs.ReadExactlyAsync(buffer, 0, buffer.Length);
            string textFromFile = Encoding.Default.GetString(buffer);
            Console.WriteLine($"Text from file: {textFromFile}");
        }*/
        
        // ---- Random file access ----
        /*string path = @"note.dat";
        string text = "Hello World";

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] input = Encoding.Default.GetBytes(text);
            fs.Write(input, 0, input.Length);
            Console.WriteLine("Text has been written to file.");
        }

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            fs.Seek(-5, SeekOrigin.End);
            
            byte[] output = new byte[5];
            await fs.ReadAsync(output, 0, output.Length);
            string textFromFile = Encoding.Default.GetString(output);
            Console.WriteLine($"Text: {textFromFile}");
        }*/
        
        // ---- Complex examole ----
        /*string path = "note2.dat";
 
        string text = "hello world";
 
// запись в файл
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        {
            // преобразуем строку в байты
            byte[] input = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            fstream.Write(input, 0, input.Length);
            Console.WriteLine("Текст записан в файл");
        }
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        { 
            // заменим в файле слово world на слово house
            string replaceText = "house";
            fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока
            byte[] input = Encoding.Default.GetBytes(replaceText);
            await fstream.WriteAsync(input, 0, input.Length);
 
            // считываем весь файл
            // возвращаем указатель в начало файла
            fstream.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[fstream.Length];
            await fstream.ReadAsync(output, 0, output.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}"); // hello house
        }*/
        
        // ---- StreamWriter & StreamReader ----
        /*string path = @"note1.dat";
        string text = "Hello World\nHello METANIT.COM";

        using (StreamWriter writer = new StreamWriter(path, true))
        {
            await writer.WriteLineAsync(text);
        }

        using (StreamWriter writer = new StreamWriter(path, true))
        {
            await writer.WriteLineAsync("Addition");
            await writer.WriteAsync("4,5");
        }*/

        /*string path = @"note1.txt";
        using (StreamReader reader = new StreamReader(path))
        {
            string text = await reader.ReadToEndAsync();
            Console.WriteLine(text);
        }

        using (StreamReader reader = new StreamReader(@"C:\app\note.txt"))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                Console.WriteLine(line);
            }
        }*/
        
        // ========== BinaryWriter & BinaryReader ==========

        string path = "person.dat";

        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
        {
            writer.Write("Tom");
            writer.Write(37);
            Console.WriteLine("File has been written");
        }
        
        string path2 = "people.dat";

        Person[] people =
        {
            new Person("Tom", 37),
            new Person("Bob", 41)
        };

        using (BinaryWriter writer = new BinaryWriter(File.Open(path2, FileMode.OpenOrCreate)))
        {
            foreach (Person person in people)
            {
                writer.Write(person.Name);
                writer.Write(person.Age);
            }
            Console.WriteLine("File has been written");
        }

        // ---- BinaryReader ----
        using (BinaryReader reader = new BinaryReader(File.Open(@"person.dat", FileMode.Open)))
        {
            string name = reader.ReadString();
            int age = reader.ReadInt32();
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
        
        // ------ Tema ------
        List<Person> persons = new List<Person>();

        using (BinaryReader reader = new BinaryReader(File.Open(@"people.dat", FileMode.Open)))
        {
            while (reader.PeekChar() > -1)
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                persons.Add(new Person(name, age));
            }
        }   

        foreach (var person in persons)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}