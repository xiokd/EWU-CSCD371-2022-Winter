
class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Hello, World!");
            GetNumberFromConsole();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            // throw;
        }
    }

    private static void GetNumberFromConsole()
    {
        int? number = null;
        while (number is null)
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();
            if (input is not null)
            {
                number=EnterNumber(number, input);
            }
            else
            {
                Console.WriteLine("Quit");
                return;
            }
        }
    }

    private static int? EnterNumber(int? number, string input)
    {
        try
        {
            number = int.Parse(input);
            Console.WriteLine($"The value is: {number} ");
        }
        catch (Exception exception) // Need to change this exception type.
        {
            throw new ArgumentException(
                message:"Input is not a valid integer.", 
                paramName:nameof(input),
                innerException: exception);
        }

        return number;
    }
}