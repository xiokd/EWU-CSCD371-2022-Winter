Console.WriteLine("Hello, World!");

Console.Write("Enter a number");
string? input = Console.ReadLine();
if (input is not null)
{
    int number = int.Parse(input);
    Console.WriteLine($"The value is: {number} ");
}
