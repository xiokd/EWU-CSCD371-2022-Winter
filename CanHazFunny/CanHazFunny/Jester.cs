using System;

namespace CanHazFunny
{
    public class Jester
    {
        private IGetJoke _JokeService;
        private IPrint _PrintService;

        public Jester(IGetJoke jokeService, IPrint printService)
        {
            _JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            _PrintService = printService ?? throw new ArgumentNullException(nameof(printService));
        }

        public void TellJoke()
        {
            string joke = _JokeService.GetJoke();

            if (joke == null) { throw new ArgumentNullException(nameof(joke)); }

            while (joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
                joke = _JokeService.GetJoke();

            _PrintService.Print(joke);
        }
    }
}