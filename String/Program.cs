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
        
        // Compare
        int result = string.Compare(str1, str2);
        if (result < 0)
        {
            Console.WriteLine("Строка str1 перед строкой str2");
        }
        else if (result > 0)
        {
            Console.WriteLine("Строка str1 стоит после строки str2");
        }
        else
        {
            Console.WriteLine("Строки str1 и str2 илентичны");
        }
        Console.WriteLine();
        
        // Searching in strings
        string st1 = "hello world";
        char ch = 'o';
        int indexOfChar = st1.IndexOf(ch);
        Console.WriteLine(indexOfChar);

        string substring = "wor";
        int indexOfSubstring = st1.IndexOf(substring);
        Console.WriteLine(indexOfSubstring);
        Console.WriteLine();

        var files = new string[]
        {
            "myapp.exe",
            "forest.jpg",
            "main.exe",
            "book.pdf",
            "river.png"
        };
        for(int i = 0; i < files.Length; i++)
        {
            if (files[i].EndsWith(".exe"))
                Console.WriteLine(files[i]);
        }
        Console.WriteLine();
        
        // Split
        string text = "И поэтому все так произошло";
        string[] words = text.Split([' '], StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in words)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine();
        
        // Trim
        text = "hello world";

        text = text.Trim();
        Console.WriteLine(text);
        text = text.Trim(new[] { 'd', 'h' });
        Console.WriteLine(text);
        
        // Substring 
        text = "Хороший день";
        text = text.Substring(2);
        Console.WriteLine(text);
        
        text = text.Substring(0, text.Length - 2);
        Console.WriteLine(text);
        
        // Insert
        text = "Хороший день";
        substring = "замечательный ";
        
        text = text.Insert(8, substring);
        Console.WriteLine(text);
        Console.WriteLine();
        
        // Remove
        text = "Хороший день";

        int ind = text.Length - 1;
        
        text = text.Remove(ind);
        Console.WriteLine(text);

        text = text.Remove(0, 2);
        Console.WriteLine(text);
        
        // Replace
        text = "Хороший день";
        text = text.Replace("Хороший", "Плохой");
        Console.WriteLine(text);

        text = text.Replace("о", "");
        Console.WriteLine(text);
        
        // ToUpper() & ToLower()
        string hello = "Hello World!";

        Console.WriteLine(hello.ToUpper());
        Console.WriteLine(hello.ToLower());
    }
}