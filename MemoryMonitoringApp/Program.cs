class Program
{
    public static void Main(string[] args)
    {
        long maxMemoryUsage = 500 * 1024 * 1024;
        using (var monitor = new MemoryMonitoring(maxMemoryUsage))
        {
            monitor.MemoryThresholdReached += (sender, e) =>
            {
                Console.WriteLine("Використання пам'яті наблизилось до критичного рівня!");
            };
            Console.WriteLine("Розпочато моніторинг ресурсів...");
            Console.WriteLine("Програма очікує поки користувач натисне Enter");
            Console.ReadLine(); 
        }

        Console.WriteLine("Моніторинг завершено.");
    }
}