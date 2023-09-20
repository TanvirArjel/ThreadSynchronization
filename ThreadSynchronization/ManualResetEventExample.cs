using System;
using System.Threading;

namespace ThreadSynchronization;

public class ManualResetEventExample
{
    private static readonly ManualResetEvent _manualResetEvent = new(false);

    public static void Execute()
    {
        Thread writeThread = new(WriteFile);
        writeThread.Start();

        // Read the file from multiple thread simultaneously.
        for (int i = 0; i < 5; i++)
        {
            Thread readThread = new(ReadFile);
            readThread.Start();

        }
    }
    private static void WriteFile()
    {
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Writing file started......");
        _manualResetEvent.Reset();

        // Consider this as writing file code 
        Thread.Sleep(3000);

        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Writing file finished.");
        _manualResetEvent.Set();
    }

    private static void ReadFile()
    {
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Waiting for the write to be completed.");
        _manualResetEvent.WaitOne();

        // Consider this is as long running reading code.
        Thread.Sleep(2000);

        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Reading file completed.");
    }
}
