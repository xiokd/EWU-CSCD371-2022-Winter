namespace WordleApp
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsValidGuess { get; set; }
        public string Message { get; set; }

        public Response(T data)
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
}
