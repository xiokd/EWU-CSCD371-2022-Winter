using System;

namespace CanHazFunny
{
    public class Jester
    {
        private JokeService _jokeService;
        private PrintService _printService;

        public Jester(JokeService jokeService, PrintService printService)
        {
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            _printService = printService ?? throw new ArgumentNullException(nameof(printService));
        }

        public void TellJoke()
        {
            string joke = _jokeService.GetJoke();

            while (joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
                joke = _jokeService.GetJoke();

            _printService.Print(joke);
        }
    }
}