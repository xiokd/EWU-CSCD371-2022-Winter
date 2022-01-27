using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_GivenValidFile_Success()
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var logger = new FileLogger(filePath)
            {
                ClassName = nameof(FileLoggerTests)
            };

            // Act
            logger.Log(LogLevel.Information, "test");
            
            // Assert
            string[] lines = File.ReadAllLines(filePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains("Information: test"));
        }

        [TestMethod]
        public void Log_GivenData_AppendsDataToFile()
    {
        // Arrange
        string filePath = Path.GetFullPath(Path.GetRandomFileName());
        var logger = new FileLogger(filePath)
        {
            ClassName = nameof(FileLoggerTests)
        };

        // Act
        logger.Log(LogLevel.Error, "test error");
        logger.Log(LogLevel.Debug, "test debug");
        logger.Log(LogLevel.Warning, "test warning");

        // Assert
        string[] lines = File.ReadAllLines(filePath);
        Assert.AreEqual(3, lines.Length);
        Assert.IsTrue(lines[0].Contains("Error: test error"));
        Assert.IsTrue(lines[1].Contains("Debug: test debug"));
        Assert.IsTrue(lines[2].Contains("Warning: test warning"));
    }
    }
