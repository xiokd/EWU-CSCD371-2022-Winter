using System;

namespace CanHazFunny
{
    public class PrintToConsoleService : IPrint
    {

        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}