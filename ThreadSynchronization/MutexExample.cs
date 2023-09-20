using System;
using System.Threading;

namespace ThreadSynchronization;

public class MutexExample
{
    private static readonly Mutex _mutex = new();

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
        _mutex.WaitOne();

        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} is writing to the file.");
        Thread.Sleep(3000);

        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} : writing completed.");
        _mutex.ReleaseMutex();
    }
}

// Mutex works similarly as AutoResetEvent except Mutex prevent the to release the lock from any where except the thread
// that locked it.
