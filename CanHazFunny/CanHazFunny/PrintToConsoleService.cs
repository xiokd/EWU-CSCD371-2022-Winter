using System;

namespace CanHazFunny
{
    public class PrintToConsoleService : IPrint
    {

        public void Print(string text)
        {
            if(text is null) { throw new ArgumentNullException("Parameter text is null"); }
            if(text == string.Empty) { throw new ArgumentException("Parameter text is empty"); }

            Console.WriteLine(text);
        }
    }
}