using System;
using System.Security.Cryptography;
using System.Threading;

namespace ThreadSynchronization;

public static class LockExample
{
    private static object _locker = new object();

    public static void Execute()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new(LockExample.DoSomeLongRunningWorkLock);
            thread.Start();
        }
    }

    private static void DoSomeLongRunningWorkLock()
    {
        // Only one thread can access the code under lock at the same time.
        lock (_locker)
        {
            try
            {
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
        }
    }
}
