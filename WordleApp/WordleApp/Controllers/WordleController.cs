using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace WordleApp.Controllers
{
    [Route("api/wordle")]
    [ApiController]
    public class WordleController : ControllerBase
    {
        private static List<string>? _Words;
        private const string ValidLetters = "abcdefghijklmnopqrstuvwxyz";

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

            return CheckGuess(guess.MyGuess, word);
        }


        public static Response CheckGuess(string? guess, string word)
        {
            if (guess is null) return new Response($"Guess cannot be blank");

            if (guess.Length != 5) return new Response($"Guess must be 5 letters");

            guess = SanitizeInput(guess);
            word = SanitizeInput(word);

            if (!IsWord(guess)) return new Response($"{guess} is not a word");

            // Now that we have checked everything else, actually do the guess.
            List<Letter> result = GetLetterResults(guess, word);

            return new Response(result);
        }

        public static bool IsWord(string guess)
        {
            return (Words.Contains(guess));
        }

        public static List<Letter> GetLetterResults(string guess, string word)
        {
            var result = new Letter[5];
            var remainingLetters = word.ToList();

            // First check to see if there are exact matches and remove from the remainingLetters
            for (int index = 0; index < guess.Length; index++)
            {
                if (word[index] == guess[index])
                {
                    var letter = new Letter { Character = guess[index], State = Validness.RightLetterRightPlace };
                    result[index] = letter;
                    remainingLetters.Remove(guess[index]);
                }
            }

            // Now check the rest of the letters, out of place or don't exist.
            for (int index = 0; index < guess.Length; index++)
            {
                // Only check letters that haven't been found.
                if (result[index] is null)
                {
                    // See if this letter is in the word.
                    if (remainingLetters.Contains(guess[index]))
                    {
                        var letter = new Letter { Character = guess[index], State = Validness.RightLetterWrongPlace };
                        result[index] = letter;
                        remainingLetters.Remove(guess[index]);
                    }
                    else // It is just a wrong letter.
                    {
                        var letter = new Letter { Character = guess[index], State = Validness.WrongLetter };
                        result[index] = letter;
                    }
                }
            }

            return result.ToList();
        }

        // Route = /api/wordle/WordCount
        [HttpGet("PossibleWords")]
        public int PossibleWords(string? correctLetters, string? otherLetters)
        {
            if (correctLetters == null) correctLetters = "";
            if (otherLetters == null) otherLetters = "";
            correctLetters = SanitizeInput(correctLetters,"?. *")
                .Replace('?', '.')
                .Replace(' ', '.')
                .Replace('*', '.')
                .PadRight(5, '.');
            otherLetters = SanitizeInput(otherLetters);
            List<string> matches = new();
            if (otherLetters.Length == 0)
            {
                return Words.Count(f => Regex.IsMatch(f, correctLetters, RegexOptions.None));
            }
            else
            {
                string currentLetters = correctLetters.Replace(".", "");
                var query = Words.Where(f => Regex.IsMatch(f, correctLetters, RegexOptions.None));
                foreach (var c in otherLetters)
                {
                    if (currentLetters.Contains(c))
                    {
                        // Check for multiples of the same letter.
                        currentLetters += c;
                        var count = currentLetters.Split(c).Length - 1;
                        query = query.Where(f => f.Split(c).Length - 1 == count);
                    }
                    else
                    {
                        query = query.Where(f => f.Contains(c));
                        currentLetters += c;
                    }
                }
                return query.Count();
            }
        }

        public static string SanitizeInput(string word, string otherValidChars = "")
        {
            word = word.ToLower();
            string result = "";
            var validLetters = ValidLetters + otherValidChars;
            foreach (var c in word)
            {
                if (validLetters.Contains(c)) result += c;
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
