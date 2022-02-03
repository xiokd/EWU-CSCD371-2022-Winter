using System;

namespace CanHazFunny
{
    public class Jester
    {
        private JokeService _JokeService;
        private PrintService _PrintService;

        public Jester(JokeService jokeService, PrintService printService)
        {
            _JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            _PrintService = printService ?? throw new ArgumentNullException(nameof(printService));
        }

        public void TellJoke()
        {
            string joke = _JokeService.GetJoke();

            while (joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
                joke = _JokeService.GetJoke();

            _PrintService.Print(joke);
        }
    }
}