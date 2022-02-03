using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_GivenJokeServiceAndPrintService_Success()
        {
            var jokeService = new JokeService();
            var printService = new PrintService();
            var jester = new Jester(jokeService, printService);

            // somehow test TellJoke() - make sure not empty?
            // check that joke does not contain Chuck Norris
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeService_ThrowsException()
        {
            _ = new Jester(null, new PrintService());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullPrintService_ThrowsException()
        {
            _ = new Jester(new JokeService(), null);
        }


        [TestMethod]
        public void TellJoke_JesterJokeOutputIsNotNullOrEmpty_False()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            new Jester(new JokeService(), new PrintService()).TellJoke();

            Assert.IsFalse(String.IsNullOrEmpty(stringWriter.ToString()));
        }

    }
}
