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
    }
}