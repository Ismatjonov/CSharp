using System.Threading.Channels;

namespace Times;

class Program
{
    static void Main(string[] args)
    {
        DateTime dateTime = new DateTime();
        Console.WriteLine(dateTime);

        Console.WriteLine(DateTime.MinValue);
        
        DateTime myDate = new DateTime(2006, 06, 26);
        Console.WriteLine(myDate);
        
        Console.WriteLine();

        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTime.UtcNow);
        Console.WriteLine(DateTime.Today);
        
        Console.WriteLine();
        
        DateTime someDate = new DateTime(1582, 10, 5);
        Console.WriteLine(someDate.DayOfWeek);

        Console.WriteLine();
        
        // Add methods
        DateTime date = new DateTime(2015, 7, 20, 18, 30, 25);
        Console.WriteLine(date.AddMinutes(45));
        Console.WriteLine();
        
        // Subtract methods
        DateTime date1 = new DateTime(2015, 7, 20, 18, 30, 25);
        DateTime date2 = new DateTime(2015, 7, 20, 15, 30, 25);
        Console.WriteLine(date1.Subtract(date2));
        Console.WriteLine();
        
        date1 = new DateTime(2015, 7, 20, 18, 30, 25);
        Console.WriteLine(date1.AddHours(-3));
        Console.WriteLine();
        
        // Date formating
        Console.WriteLine(date1.ToLocalTime());
        Console.WriteLine(date1.ToUniversalTime());
        Console.WriteLine(date1.ToLongDateString());
        Console.WriteLine(date1.ToShortDateString());
        Console.WriteLine(date1.ToLongTimeString());
        Console.WriteLine(date1.ToShortTimeString());
        Console.WriteLine();
        
        // ======== Formatting dates and times ========
        DateTime now = DateTime.Now;

        Console.WriteLine($"D: {now.ToString("D")}");
        Console.WriteLine($"d: {now.ToString("d")}");
        Console.WriteLine($"F: {now.ToString("F")}");
        Console.WriteLine($"f: {now:f}");
        Console.WriteLine($"G: {now:G}");
        Console.WriteLine($"g: {now:g}");
        Console.WriteLine($"M: {now:M}");
        Console.WriteLine($"O: {now:O}");
        Console.WriteLine($"o: {now:o}");
        Console.WriteLine($"R: {now:R}");
        Console.WriteLine($"s: {now:s}");
        Console.WriteLine($"T: {now:T}");
        Console.WriteLine($"t: {now:t}");
        Console.WriteLine($"U: {now:U}");
        Console.WriteLine($"u: {now:u}");
        Console.WriteLine($"Y: {now:Y}");
        
    }
}