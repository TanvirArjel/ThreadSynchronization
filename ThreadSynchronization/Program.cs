namespace ThreadSynchronization;

public class Program
{
    private static void Main(string[] args)
    {
        SemaphoreExample.Execute();
    }
}

// Here we will learn thread synchronization using lock, monitor, manual reset event, auto reset event,  mutex and 
// semaphore or semaphoreSlim keywords
// Thread synchronization requires for the expensive resources like file, network