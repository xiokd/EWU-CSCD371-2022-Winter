using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordleApp.Tests
{
    [TestClass]
    public class WordleTests
    {
        [TestMethod]
        public void CheckWord()
        {
            var result = WordleApp.Controllers.WordleController.GetLetterResults("ABEGF", "GUESS");
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[0].State);
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[1].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterRightPlace, result[2].State);
            Assert.AreEqual(WordleApp.Validness.RightLetteWrongPlace, result[3].State);
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[4].State);
        }

        [TestMethod]
        public void IsWord()
        {
            Assert.IsTrue(WordleApp.Controllers.WordleController.IsWord("smile"));
            Assert.IsTrue(WordleApp.Controllers.WordleController.IsWord("quake"));
        }


        [TestMethod]
        public void CheckGuess()
        {
            var result = WordleApp.Controllers.WordleController.CheckGuess(new Controllers.Guess { MyGuess = null, WordIndex = 2}, "tests");
            Assert.IsFalse(result.IsValidGuess);
            result = WordleApp.Controllers.WordleController.CheckGuess(new Controllers.Guess { MyGuess = "", WordIndex = 2 }, "tests");
            Assert.IsFalse(result.IsValidGuess);
            result = WordleApp.Controllers.WordleController.CheckGuess(new Controllers.Guess { MyGuess = "asdfd", WordIndex = 2 }, "tests");
            Assert.IsFalse(result.IsValidGuess);
            result = WordleApp.Controllers.WordleController.CheckGuess(new Controllers.Guess { MyGuess = "aback", WordIndex = 1 }, "tests");
            Assert.IsTrue(result.IsValidGuess);
        }

        [TestMethod]
        public void Guess() 
        {
            var controller = new WordleApp.Controllers.WordleController();
            var result = controller.Guess(new Controllers.Guess { MyGuess = "aback", WordIndex = 1 });
            Assert.IsTrue(result.IsValidGuess);
        }

        [TestMethod]
        public void WordCount()
        {
            var controller = new WordleApp.Controllers.WordleController();
            var result = controller.GetWordCount();
            Assert.AreEqual(result, 4266);
        }
    }
}