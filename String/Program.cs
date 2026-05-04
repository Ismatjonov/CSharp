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

        string message = "Hello";
        char firstChar = message[0];
        Console.WriteLine(firstChar);
        Console.WriteLine(message.Length);
        Console.WriteLine();
        
        // Enumerate string
        for (int i = 0; i < message.Length; i++)
        {
            Console.WriteLine(message[i]);
        }
        Console.WriteLine();
        foreach (var c in message)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
        
        // Compare strings
        string message1 = "Hello";
        string message2 = "Hello";
        Console.WriteLine(message1 == message2);
        
        // Multi-line strings
        Print();
        PrintValue("hello");

        void Print()
        {
            string text = """
                          <element attr="content">
                            <body>
                            </body>
                          </element>
                          """;
        }

        void PrintValue(string val)
        {
            string text = $"""
                           <element attr="content">
                           <body>
                            {val}
                           </body>
                           </element>
                           """;
            Console.WriteLine(text);
        }
        Console.WriteLine();

        // ======== Operation with strings ========

        // Concat & Join
        string str1 = "hello";
        string str2 = "world";
        string str3 = str1 + " " + str2;
        string str4 = string.Concat(str3, "!!!");
        Console.WriteLine(str4);

        string s5 = "apple";
        string s6 = "a day";
        string s7 = "keeps";
        string s8 = "a doctor";
        string s9 = "away";
        string[] values = new string[] { s5, s6, s7, s8, s9 };
        
        string s10 = string.Join(" ", values);
        Console.WriteLine(s10);
    }
}