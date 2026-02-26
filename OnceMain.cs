using System;
using System.Threading.Tasks;

namespace once;

public class OnceMain
{
    private static readonly Lazy<OnceMain> _instance = new(() => new OnceMain());
    
    public static OnceMain Instance => _instance.Value;

    bool isInitialized = false;
    
    private OnceMain()
    {
        Initialize();
    }

    public Task WaitForInitialization()
    {
        while (!isInitialized)
        {
            Task.Delay(10).Wait(); // Wait 10ms before checking again
        }
        return Task.CompletedTask;
    }
    
    private void Initialize()
    {
        // Initialize services, load config, etc.
        Console.WriteLine("OnceMain initialized");

        isInitialized = true;
    }
}