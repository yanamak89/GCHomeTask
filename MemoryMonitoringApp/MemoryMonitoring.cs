using System;
using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

public class MemoryMonitoring : IDisposable
{
    private readonly Timer _monitoringTimer;
    private readonly long _maxMemoryUsage;
    private readonly Process _currentProcess;

    public event EventHandler MemoryThresholdReached;

    public MemoryMonitoring(long maxMemoryUsage, double monitoringIntervalInSeconds = 1.0)
    {
        _maxMemoryUsage = maxMemoryUsage;
        _currentProcess = Process.GetCurrentProcess();

        _monitoringTimer = new Timer(monitoringIntervalInSeconds * 1000);
        _monitoringTimer.Elapsed += MonitorResources;
        _monitoringTimer.Start();
    }

    private void MonitorResources(object sender, ElapsedEventArgs e)
    {
        long currentMemoryUsage = _currentProcess.WorkingSet64;

        Console.WriteLine($"Current memory usage: {currentMemoryUsage / (1024 * 1024)} MB");

        if (currentMemoryUsage >= _maxMemoryUsage)
        {
            OnMemoryThresholdReached(EventArgs.Empty);
        }
    }

    protected virtual void OnMemoryThresholdReached(EventArgs e)
    {
        MemoryThresholdReached?.Invoke(this, e);
        Console.WriteLine("Warning: Memory usage has reached the defined threshold!");
    }

    public void Dispose()
    {
        _monitoringTimer?.Stop();
        _monitoringTimer?.Dispose();
        _currentProcess?.Dispose();
    }
}