using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordleApp.Tests
{
    [TestClass]
    public class WordleTests
    {
        [TestMethod]
        public void CheckWordGuess()
        {
            var result = WordleApp.Controllers.WordleController.GetLetterResults("ABEGF", "GUESS");
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[0].State);
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[1].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterRightPlace, result[2].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterWrongPlace, result[3].State);
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[4].State);
        }

        [TestMethod]
        public void CheckWordShall()
        {
            var result = WordleApp.Controllers.WordleController.GetLetterResults("palls", "shall");
            Assert.AreEqual(WordleApp.Validness.WrongLetter, result[0].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterWrongPlace, result[1].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterWrongPlace, result[2].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterRightPlace, result[3].State);
            Assert.AreEqual(WordleApp.Validness.RightLetterWrongPlace, result[4].State);
        }

        [TestMethod]
        public void CheckWordWin()
        {
            var result = WordleApp.Controllers.WordleController.CheckGuess("rough", "rough");
            Assert.IsTrue(result.Winner);
        }

        [TestMethod]
        public void CheckWordNotWin()
        {
            var result = WordleApp.Controllers.WordleController.CheckGuess("rough", "route");            Assert.IsFalse(result.Winner);
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
            var result = WordleApp.Controllers.WordleController.CheckGuess(null, "tests");
            Assert.IsFalse(result.IsValidGuess);
            result = WordleApp.Controllers.WordleController.CheckGuess("", "tests");
            Assert.IsFalse(result.IsValidGuess);
            result = WordleApp.Controllers.WordleController.CheckGuess("asdfd", "tests");
            Assert.IsFalse(result.IsValidGuess);
            result = WordleApp.Controllers.WordleController.CheckGuess("aback", "tests");
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

        [TestMethod]
        public void PossibleWords()
        {
            var controller = new WordleApp.Controllers.WordleController();
            var count = controller.PossibleWords("g.u.s","");
            Assert.AreEqual(3, count);
            count = controller.PossibleWords("", "gus");
            Assert.AreEqual(34, count);
            count = controller.PossibleWords("gr...", null);
            Assert.AreEqual(51, count);
            count = controller.PossibleWords("g.u.s", "e");
            Assert.AreEqual(1, count);
            count = controller.PossibleWords("g.u.s", "a");
            Assert.AreEqual(1, count);
            count = controller.PossibleWords(".....", "gran");
            Assert.AreEqual(13, count);
        }

        [TestMethod]
        public void PossibleWordsDuplicateLetters()
        {
            var controller = new WordleApp.Controllers.WordleController();
            int count;
            count = controller.PossibleWords("", "gsus");
            Assert.AreEqual(3, count); // guess, slugs, gusts
            count = controller.PossibleWords("gu..s", "s");
            Assert.AreEqual(2, count); // guess, slugs, gusts
            count = controller.PossibleWords("gu..s", "sl");
            Assert.AreEqual(0, count); // none
            count = controller.PossibleWords("s.ug.", "sl");
            Assert.AreEqual(1, count); // none
            count = controller.PossibleWords("slu", "sg");
            Assert.AreEqual(1, count); // none
            count = controller.PossibleWords("sl", "sg");
            Assert.AreEqual(3, count); // slags, slogs, slugs
        }

        [TestMethod]
        public void SanitizeInput()
        {
            var result = Controllers.WordleController.SanitizeInput("Gr/asd?*", "*");
            Assert.AreEqual("grasd*", result);
        }
    }
}