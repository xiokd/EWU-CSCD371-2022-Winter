namespace WordleApp
{
    public class Response
    {
        public List<Letter>? Data { get; set; }
        public bool IsValidGuess { get; set; }
        public string? Message { get; set; }

        public Response(List<Letter> data)
        {
            Data = data;
            IsValidGuess = true;
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
        RightLetteWrongPlace = 1,
        RightLetterRightPlace = 2
    }
}
