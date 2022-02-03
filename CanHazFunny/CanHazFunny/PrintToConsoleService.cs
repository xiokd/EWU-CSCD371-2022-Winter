using System;

namespace CanHazFunny
{
    public class PrintToConsoleService : IPrint
    {

        public void Print(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            Console.WriteLine(text);
        }
    }
}