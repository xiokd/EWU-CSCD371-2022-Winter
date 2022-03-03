using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordleApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckWord()
        {
            var result = WordleApp.Controllers.WordleController.CheckGuess("ABEGF", "GUESS");
            Assert.AreEqual(WordleApp.Controllers.Validness.WrongLetter, result[0].State);
            Assert.AreEqual(WordleApp.Controllers.Validness.WrongLetter, result[1].State);
            Assert.AreEqual(WordleApp.Controllers.Validness.RightLetterRightPlace, result[2].State);
            Assert.AreEqual(WordleApp.Controllers.Validness.RightLetteWrongPlace, result[3].State);
            Assert.AreEqual(WordleApp.Controllers.Validness.WrongLetter, result[4].State);
        }
    }
}