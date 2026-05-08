using System.Text;
using System.Text.RegularExpressions;

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
        Console.WriteLine();
        
        // ======== String formating and interpolation ========
        string name = "Tom";
        int age = 23;
        string output = string.Format("Имя: {0} Возраст: {1}", name, age);
        Console.WriteLine(output);
        Console.WriteLine();
        
        // Currency formating
        double number = 23.7;
        string r = string.Format("{0:C0}", number);
        Console.WriteLine(r);
        string r2 = string.Format("{0:C2}", number);
        Console.WriteLine(r2);
        Console.WriteLine();
        
        // Integer formating
        int num = 23;
        string r3 = string.Format("{0:d}", num);
        Console.WriteLine(r3);
        string r4 = string.Format("{0:d4}", num);
        Console.WriteLine(r4);
        Console.WriteLine();
        
        // Formating fractional numbers
        int number1 = 23;
        string r5 = string.Format("{0:f}", number1);
        Console.WriteLine(r5);

        double number2 = 45.08;
        string r6 = string.Format("{0:f4}", number2);
        Console.WriteLine(r6);
        
        double number3 = 25.07;
        string r7 = string.Format("{0:f1}", number3);
        Console.WriteLine(r7);
        Console.WriteLine();
        
        // Percent formation
        decimal n = 0.15345m;
        Console.WriteLine("{0:P2}", n);
        Console.WriteLine();
        
        // Customize formation
        long l = 19876543210;
        string rs = string.Format("{0:+# (###) ###-##-##}", l);
        Console.WriteLine(rs);
        // Method: ToString()
        Console.WriteLine(l.ToString("+# (###) ###-##-##"));
        double money = 24.8;
        Console.WriteLine(money.ToString("C2"));
        Console.WriteLine();
        
        // == Interpolation ==
        name = "Tom";
        age = 23;
        Console.WriteLine($"Имя: {name}, Возраст: {age}");

        int x = 8;
        int y = 7;
        string _result = $"{x} + {y} = {x + y}";
        Console.WriteLine(_result);
        _result = $"{x} * {y} = {Multiply(x, y)}";
        Console.WriteLine(_result);
        int Multiply(int a, int b) => a * b;
        Console.WriteLine();

        long phone = 992937770771;
        Console.WriteLine($"{phone:+### ## ### ## ##}");
        Console.WriteLine();

        name = "Bakhtovar";
        age = 19;
        Console.WriteLine($"Имя: {name, -5} Возраст: {age}");
        Console.WriteLine($"Имя: {name, 5} Возраст: {age}");    // didn't get it...
        Console.WriteLine();
        
        
        // ======== Class StringBuilder ========
        // StringBuilder sb = new StringBuilder();  // Creating StringBuilder class
        
        // StringBuilder sb = new StringBuilder("Привет мир");  // Creating with initializer

        var sb = new StringBuilder("Hello World");
        Console.WriteLine(sb.ToString());
        Console.WriteLine(sb);

        Console.WriteLine($"Length: {sb.Length}");
        Console.WriteLine($"Capacity: {sb.Capacity}");

        var sb2 = new StringBuilder("Hello World", 32);
        Console.WriteLine();
        
        // Operations with string in StringBuilder
        sb = new StringBuilder("Название: ");
        Console.WriteLine(sb);
        Console.WriteLine($"Length: {sb.Length}");
        Console.WriteLine($"Capacity: {sb.Capacity}");

        sb.Append(" Руководство");
        Console.WriteLine(sb);
        Console.WriteLine($"Length: {sb.Length}");
        Console.WriteLine($"Capacity: {sb.Capacity}");

        sb.Append(" по C#");
        Console.WriteLine(sb);
        Console.WriteLine($"Length: {sb.Length}");
        Console.WriteLine($"Capacity: {sb.Capacity}");
        Console.WriteLine();

        sb = new StringBuilder("Привет мир");
        sb.Append("!");
        sb.Insert(7, "компютерный ");
        Console.WriteLine(sb.ToString());
        
        // Replacing word
        sb.Replace("мир", "world");
        Console.WriteLine(sb);
        
        // Removing
        sb.Remove(7, 12);
        Console.WriteLine(sb);
        Console.WriteLine();
        
        string t = sb.ToString();
        Console.WriteLine(t);
        Console.WriteLine();
        
        // ======= Regular Expressions ========
        string S = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
        Regex regex = new Regex(@"туп(\w*)");
        MatchCollection matches = regex.Matches(S);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
                Console.WriteLine(match.Value);
        }
        else
        {
            Console.WriteLine("Совпадений не найдено");
        }
        Console.WriteLine();

        Regex reg = new Regex(@"\w*губ\w*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        matches = reg.Matches(S);
        if (matches.Count > 0)
            foreach (var match in matches)
                Console.WriteLine(match);
        else
            Console.WriteLine("No matches");
        Console.WriteLine();

        string _s = "456-435-23118";
        Regex regex2 = new Regex(@"\d{3}-\d{3}-\d{4}");

        regex2 = new Regex(@"[0-9]{3}-[0-9]{3}-[0-9]{4}");
        
        // Checking if a string matches the format
        string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        var data2 = new string[]
        {
            "tom@gmail.com",
            "+12345678999",
            "bob@yahoo.com",
            "+12345465566",
            "sam@yandex.ru",
            "+43743989393"
        };
        Console.WriteLine("Email List");
        for (int i = 0; i < data2.Length; i++)
        {
            if (Regex.IsMatch(data2[i], pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine(data2[i]);
            }
        }
        Console.WriteLine();
        
        // Replace and method Replace()
        string txt = "Мама  мыла  раму.";
        string patternn = @"\s+";
        string target = " ";
        Regex rgx = new Regex(patternn);
        string rslt = rgx.Replace(txt, target);
        Console.WriteLine(rslt);
        Console.WriteLine();

        string phoneNumber = "+992(93)-777-07-71";
        string patt = @"\D+";
        string tgt = "";
        Regex rgx2 = new Regex(patt);
        string rslt2 = rgx2.Replace(phoneNumber, tgt);
        Console.WriteLine(rslt2);
    }
}