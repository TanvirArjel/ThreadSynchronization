using System;
using System.Security.Cryptography;
using System.Threading;

namespace ThreadSynchronization;

public class MonitorExample
{
    private static readonly object _locker = new();

    public static void Execute()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new(DoSomeLongRunningWorkMonitor);
            thread.Start();
        }
    }

    private static void DoSomeLongRunningWorkMonitor()
    {
        try
        {
            // Only one thread can access the code under monitor at the same time.
            Monitor.Enter(_locker);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started.");
            Thread.Sleep(3000);
            int randomNumber = RandomNumberGenerator.GetInt32(10, 21);

            if (randomNumber % 2 == 0)
            {
                Convert.ToInt32("Hell0");
            }

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Monitor.Exit(_locker);
        }
    }
}

// What is diff between lock and monitor?
// Answer: With monitor we have more control over the code
// One key difference between lock and monitor called signalling. Monitor has Wait(), Pulse(), and PulseAll() methods which can be used to send signal to other threads
