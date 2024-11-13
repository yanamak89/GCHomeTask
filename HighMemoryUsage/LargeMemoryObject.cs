namespace HighMemoryUsage;

public class LargeMemoryObject : IDisposable
{
    private bool _disposed = false;
    private int[] _largeArray;
    private FileStream _fileStream; // Керований ресурс


    public LargeMemoryObject(int size, string filePath)
    {
        _largeArray = new int[size];
        Console.WriteLine($"Виділено пам'ять для масиву розміром:" +
                          $" {size * sizeof(int) / (1024 * 1024)} MB");
        // Ініціалізуємо FileStream для запису у файл
        _fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
    }

    public void InitializeArray()
    {
        for (int i = 0; i < _largeArray.Length; i++)
        {
            _largeArray[i] = i;
        }
    }

    public int GetElement(int index)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(LargeMemoryObject));
        }

        return _largeArray[index];
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Звільняємо керовані ресурси (якщо є)
                _fileStream?.Dispose();
                Console.WriteLine("FileStream звільненo");
                
            }
            // Звільняємо некеровані ресурси
            _largeArray = null;
            Console.WriteLine("Пам'ять звільнено");
            _disposed = true;
        }
    }
    // Фіналізатор на випадок, якщо Dispose не був викликаний
    ~LargeMemoryObject()
    {
        Dispose(false);
    }

}