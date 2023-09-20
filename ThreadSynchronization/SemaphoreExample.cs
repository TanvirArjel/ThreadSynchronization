using System;
using System.Threading;

namespace ThreadSynchronization;

public class SemaphoreExample
{
    private static readonly Semaphore _semaphore = new(2, 2);

    public static void Execute()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread writeThread = new(WriteFile);
            writeThread.Start();
        }
    }

    private static void WriteFile()
    {
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} : is waiting to write.");
        _semaphore.WaitOne();

        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} is writing to the file.");
        Thread.Sleep(5000);

        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} : writing completed.");
        _semaphore.Release();
    }
}

// Semaphore is not actually a locking mechanism. It's used for controlling the parallelism in
// multi-threading.
