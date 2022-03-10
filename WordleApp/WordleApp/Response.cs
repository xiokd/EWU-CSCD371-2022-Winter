namespace WordleApp
{
    public class Response
    {
        public List<Letter>? Data { get; set; }
        public bool IsValidGuess { get; set; }
        public string? Message { get; set; }
        public bool Winner { get; set; } = false;

        public Response(List<Letter> data)
        {
            Data = data;
            IsValidGuess = true;
            Winner = data.All(f => f.State == Validness.RightLetterRightPlace);
        }
        public Response(string message)
        {
            IsValidGuess = false;
            Message = message;
        }
    }

    public class Letter
    {
        public char Character { get; set; }
        public Validness State { get; set; }
    }

    public enum Validness
    {
        WrongLetter = 0,
        RightLetterWrongPlace = 1,
        RightLetterRightPlace = 2
    }
}
