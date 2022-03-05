using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WordleApp.Controllers
{
    [Route("api/wordle")]
    [ApiController]
    public class WordleController : ControllerBase
    {
        private static List<string>? _Words;

        public static List<string> Words
        {
            get
            {
                if (_Words is null)
                {
                    _Words = System.IO.File.ReadAllLines("Words.txt").ToList();
                }
                return _Words;
            }
        }

        // Route = /api/wordle/WordCount
        [HttpGet("WordCount")]
        public int GetWordCount()
        {
            return Words.Count;
        }

        [HttpPost("guess")]
        public Response Guess([FromBody] Guess guess)
        {
            if (guess == null) return new Response("You must submit a response");

            if (guess.WordIndex >= Words.Count || guess.WordIndex < 0) return new Response($"Invalid word index. Index must be between 0 and {Words.Count - 1}");
            var word = Words[guess.WordIndex];

            return CheckGuess(guess, word);
        }


        public static Response CheckGuess(Guess guess, string word)
        {
            if (guess.MyGuess is null) return new Response($"Guess cannot be blank");

            if (guess.MyGuess.Length != 5) return new Response($"Guess must be 5 letters");

            guess.MyGuess = guess.MyGuess.ToLower();

            if (!IsWord(guess.MyGuess)) return new Response("The guess is not a word");

            // Now that we have checked everything else, actually do the guess.
            List<Letter> result = GetLetterResults(guess.MyGuess!.ToLower(), word.ToLower());

            return new Response(result);
        }

        public static bool IsWord(string guess)
        {
            return (Words.Contains(guess));
        }

        public static List<Letter> GetLetterResults(string guess, string word)
        {
            List<Letter> result = new();

            int index = 0;
            foreach (char c in guess)
            {
                Letter letter;
                if (word.Contains(c))
                {
                    if (word[index] == guess[index])
                    {
                        letter = new Letter { Character = c, State = Validness.RightLetterRightPlace };
                    }
                    else
                    {
                        letter = new Letter { Character = c, State = Validness.RightLetteWrongPlace };
                    }
                }
                else
                {
                    letter = new Letter { Character = c, State = Validness.WrongLetter };
                }
                result.Add(letter);
                index++;
            }

            return result;
        }
    }

    public class Guess
    {
        public string? MyGuess { get; set; }
        public int WordIndex { get; set; }
    }

}
