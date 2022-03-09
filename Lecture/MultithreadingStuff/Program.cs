
using System.Diagnostics;

public class Program
{
    static int iterationCount = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CancellationTokenSource cancellationTokenSource = 
            new CancellationTokenSource();

        Task<int> taskDisplay = Task.Run(
            () => Display('.', cancellationTokenSource.Token)                
            );

        static void Decrement()
        {
            while (true)
            {
                Console.Write('-');
                iterationCount--;
            }
        };
        Task taskDecrement = Task.Run(Decrement);

        iterationCount--;
        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
        cancellationTokenSource.Cancel();
        iterationCount = taskDisplay.Result;
        Console.WriteLine($"IterationCount = {iterationCount}");
        Console.WriteLine("Exiting!!!");
    }
    static int Display(char character, CancellationToken cancellationToken)
    {
        iterationCount = 0;
        Thread.CurrentThread.Name = "DisplayThread";
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            iterationCount++;
        }
        return iterationCount;
    }


    public int StartProcess(int interations)
    {
        Process process = Process.Start("ping", "google.com");
        process.WaitForExit();
        return process.ExitCode;
    }
}

