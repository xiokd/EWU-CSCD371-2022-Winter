using System;

namespace CanHazFunny
{
    public class PrintService : IPrint
    {
        public PrintService()
        {
        }

        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}