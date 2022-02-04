using System;

namespace CanHazFunny
{
    public class PrintToConsoleService : IPrint
    {

        public void Print(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (text.Length == 0) throw new ArgumentException(nameof(text));

            Console.WriteLine(text);
        }
    }
}