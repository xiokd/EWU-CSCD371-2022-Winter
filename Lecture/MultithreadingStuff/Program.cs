
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Task.Run(
            () => Display('.')
            );

        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
    }
    static void Display(char character)
    {
        while (true)
        {
            Console.Write(character);
        }
    }
}

