using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_GivenValidFilePath_ReturnsFileLogger()
        {
            // Arrange
            var logFactory = new LogFactory();
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            logFactory.ConfigureFileLogger(filePath);

            // Act
            BaseLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsTrue(logger is FileLogger);
            Assert.AreEqual(nameof(LogFactoryTests), logger.ClassName);
        }

        [TestMethod]
        public void CreateLogger_GivenNullFilePath_ReturnFalse()
        {
            // Arrange
            var logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(null);

            // Act
            BaseLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsFalse(logger is FileLogger);
        }

        [TestMethod]
        public void CreateLogger_GivenLoggerNotConfigured_ReturnsNull()
        {
            // Arrange
            var logFactory = new LogFactory();

            // Act
            BaseLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsNull(logger);
        }
        
    }
