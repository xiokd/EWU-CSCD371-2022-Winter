using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingStuff;

public class HourGlass
{
    Task<int> DisplayAsnc(char character, 
        CancellationToken cancellationToken = default)
    {
        Task<int> taskDisplay = Task.Run(
            () => Display('.', cancellationToken)
            );
        return taskDisplay;
    }

    public int Display(char character, 
        CancellationToken cancellationToken = default)
    {
        int iterationCount = 0;
        Thread.CurrentThread.Name = "DisplayThread";
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            iterationCount++;
        }
        return iterationCount;
    }
}
