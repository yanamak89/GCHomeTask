# Resource Monitoring and High-Memory Object Management in C#

This project demonstrates resource management and memory monitoring in C#. It includes classes for monitoring resource usage and managing large memory allocations. The tasks involve creating a resource monitoring class, researching related topics on MSDN, and implementing a memory-intensive class with a formalized cleanup pattern.

## Table of Contents
- [Task 2: Resource Monitoring Class](#task-2-resource-monitoring-class)
- [Task 3: MSDN Research](#task-3-msdn-research)
- [Task 4: High-Memory Object with Cleanup Pattern](#task-4-high-memory-object-with-cleanup-pattern)
- [Recommended Resources](#recommended-resources)

---

## Task 2: Resource Monitoring Class

The `ResourceMonitor` class tracks memory usage of the application. The class:
- Allows users to specify acceptable memory usage levels.
- Issues a warning when memory usage approaches the maximum permissible level.

### Key Features
- Uses the `Process` class to monitor current memory usage.
- Implements a timer to check memory usage at specified intervals.
- Raises an event if the memory threshold is reached, enabling users to handle warnings.

You can view the implementation in the [MemoryMonitoringApp directory on GitHub](https://github.com/yanamak89/GCHomeTask/tree/master/MemoryMonitoringApp).

## Task 3: MSDN Research

Using the MSDN website, research the topics discussed in this lesson, including `IDisposable`, `GC.Collect()`, and `Finalize` methods. Save links to each topic with a brief description for future reference.

### Example Documentation Summary

1. **IDisposable Interface**  
   Link: [MSDN: IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable)  
   Description: Provides a mechanism for releasing unmanaged resources.

2. **GC.Collect() Method**  
   Link: [MSDN: GC.Collect](https://learn.microsoft.com/en-us/dotnet/api/system.gc.collect)  
   Description: Forces immediate garbage collection, freeing up resources after memory-intensive tasks.

3. **Finalize Method**  
   Link: [MSDN: Object.Finalize](https://learn.microsoft.com/en-us/dotnet/api/system.object.finalize)  
   Description: Allows an object to try to release resources and perform cleanup before garbage collection.

## Task 4: High-Memory Object with Cleanup Pattern

The `LargeMemoryObject` class simulates a memory-intensive object with a large internal array. This class:
- Implements the `IDisposable` interface to ensure memory is freed when the object is no longer in use.
- Includes a destructor/finalizer to release memory if `Dispose` is not called explicitly.
- Provides methods to initialize the array with various values, such as sequential, random, or index-based multipliers.

You can view the implementation in the [HighMemoryUsage directory on GitHub](https://github.com/yanamak89/GCHomeTask/tree/master/HighMemoryUsage).

## Recommended Resources
- [MSDN: Garbage Collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/)
- [MSDN: IDisposable Interface](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable)
- [MSDN: Object.Finalize Method](https://learn.microsoft.com/en-us/dotnet/api/system.object.finalize)

These resources offer detailed descriptions of garbage collection, memory management, and the `IDisposable` pattern in .NET.

---

This project showcases best practices for managing memory-intensive resources and handling cleanup in C#. Feel free to explore and customize the code for further experimentation with resource management and monitoring.
