namespace Addition;

class Program
{
    static void Main(string[] args)
    {
        Reader reader = new Reader();
        reader.ReadEbooks();
        reader.ReadBook();
        Console.WriteLine();
        
        // ======== Class Math ========
        double result = Math.Abs(-12.4); // Modul
        Console.WriteLine(result);
        
        result = Math.Acos(1);  // Arccos
        Console.WriteLine(result);

        result = Math.BigMul(100, 9340);    // x * y (long)
        Console.WriteLine(result);
        
        result = Math.Ceiling(7.06715);    //  Hue
        Console.WriteLine(result);

        int r;
        int div = Math.DivRem(14, 5, out r);    // x/y => whole -> div; remainder -> r;
        Console.WriteLine(r);
        Console.WriteLine(div);
        
        result = Math.Floor(2.56);
        Console.WriteLine(result);
        
        result = Math.IEEERemainder(26, 4);
        Console.WriteLine(result);

        double result1 = Math.Round(20.56);
        double result2 = Math.Round(20.46);
        Console.WriteLine(result1);
        Console.WriteLine(result2);

        result1 = Math.Round(20.567, 2);
        result2 = Math.Round(20.463, 1);
        Console.WriteLine(result1);
        Console.WriteLine(result2);
        
        result1 = Math.Sign(15);
        Console.WriteLine(result1);
        result2 = Math.Sign(-5);
        Console.WriteLine(result2);

        result = Math.Sqrt(16); // √x² = x
        Console.WriteLine(result);

        result = Math.Truncate(16.89);  // Drop fractional part of number
        Console.WriteLine(result);

        double radius = 50;
        double area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine($"Площадь круга с радиусом {radius} равна {Math.Round(area, 2)}");
        Console.WriteLine();
    }
}

class Reader
{
    Lazy<Library> library = new Lazy<Library>();
    public void ReadBook()
    {
        library.Value.GetBook();
        Console.WriteLine("Читаем бумажную книгу");
    }

    public void ReadEbooks()
    {
        Console.WriteLine("Читаем книгу на компьютере");
    }
}

class Library
{
    string[] books = new string[99];

    public void GetBook()
    {
        Console.WriteLine("Выдаем книгу читателю");
    }
}