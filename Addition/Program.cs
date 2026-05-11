namespace Addition;

class Program
{
    static void Main(string[] args)
    {
        Reader reader = new Reader();
        reader.ReadEbooks();
        reader.ReadBook();
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