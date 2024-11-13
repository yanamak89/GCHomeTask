using HighMemoryUsage;

class Program
{
    public static void Main(string[] args)
    {
        using (var largeObject = new LargeMemoryObject(100_000_000, "example.txt"))
        {
            largeObject.InitializeArray();
            Console.WriteLine("Елемент масиву: " + largeObject.GetElement(888));
        }

        Console.WriteLine("Об'єкт видалено після виходу з блоку using.");
    }
}