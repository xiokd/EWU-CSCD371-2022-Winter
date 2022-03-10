using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingStuff;

public class HourGlass
{
    public int Display(char character, CancellationToken cancellationToken)
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
