using System;
using System.Threading;

namespace ThreadSynchronization;

public class AutoResetEventExample
{
    private static AutoResetEvent autoResetEvent = new(true);
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
        System.Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} : is waiting to write.");
        autoResetEvent.WaitOne();

        System.Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} is writing to the file.");
        Thread.Sleep(3000);

        System.Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} : writing completed.");
        autoResetEvent.Set();
    }
}
