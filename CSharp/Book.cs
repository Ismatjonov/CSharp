namespace CSharp;

ref struct Book
{
    public Book(string title) => Title = title;
    public string Title { get; }
}

ref struct Sum
{
    private ReadOnlySpan<int> data;

    public Sum(int[] numbers, Range range)
    {
        data = numbers[range];
    }

    public int Get()
    {
        int result = 0;
        foreach (var n in data)
        {
            result += n;
        }
        return result;
    }
}

interface IShape
{
    void Draw();
}

ref struct Shape : IShape
{
    public void Draw()
    {
        Console.WriteLine("Draw some shape");
    }
}