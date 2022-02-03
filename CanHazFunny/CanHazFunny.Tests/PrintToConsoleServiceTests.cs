using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class PrintToConsoleServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Print_WithNullInput_ThrowsException()
        {
            var printToConsoleService = new PrintToConsoleService();
            printToConsoleService.Print(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Print_WithEmptyStringInput_ThrowsException()
        {
            var printToConsoleService = new PrintToConsoleService();
            printToConsoleService.Print("");
        }

    }
}
