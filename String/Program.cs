using System.Runtime.InteropServices.JavaScript;

namespace String;

class Program
{
    static void Main(string[] args)
    {
        string s1 = "hello";
        string s2 = new string('a', 6);
        string s3 = new string(new char[] { 'w', 'o', 'r', 'l', 'd' });
        string s4 = new string(new char[] { 'w', 'o', 'r', 'l', 'd' }, 1, 3);

        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(s3);
        Console.WriteLine(s4);
    }
}