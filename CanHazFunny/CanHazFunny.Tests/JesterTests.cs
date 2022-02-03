using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeService_ThrowsException()
        {
            new Jester(null!, new PrintToConsoleService());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullPrintService_ThrowsException()
        {
            new Jester(new JokeService(), null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeServiceAndNullPrintService_ThrowsException()
        {
            new Jester(null!, null!);
        }

        [TestMethod]
        public void TellJoke_OutputIsNotNullOrEmpty_False()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            new Jester(new JokeService(), new PrintToConsoleService()).TellJoke();

            Assert.IsFalse(String.IsNullOrEmpty(stringWriter.ToString()));

            stringWriter.Dispose();
        }

        [TestMethod]
        public void TellJoke_OutputContainsChuckNorris_False()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Mock<IGetJoke> jokeServiceMock = new();
            jokeServiceMock.SetupSequence(x => x.GetJoke())
                .Returns(new string("Chuck Norris"))
                .Returns(new string("this is a joke, right?"));

            new Jester(jokeServiceMock.Object, new PrintToConsoleService()).TellJoke();

            Assert.IsFalse((stringWriter.ToString()).Contains("Chuck Norris"));

            stringWriter.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TellJoke_JokeIsEmptyOrNull_ThrowsException()
        {
            Mock jester = new Mock<IGetJoke>();
        }
    }
}
