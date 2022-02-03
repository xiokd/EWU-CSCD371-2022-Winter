using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_GivenJokeServiceAndPrintService_Success()
        {
            var jokeService = new JokeService();
            var printService = new PrintToConsoleService();
            var jester = new Jester(jokeService, printService);

            // somehow test TellJoke() - make sure not empty?
            // check that joke does not contain Chuck Norris
        }

    }
}
