namespace CSharp;

partial class Buffer
{
    public partial int this[int index] { get; set; }
}

partial class Buffer
{
    public const int COUNT = 6;
    private int[] data = new int[COUNT];

    public partial int this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }
}