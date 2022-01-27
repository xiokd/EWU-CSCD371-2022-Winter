using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger;

    public class FileLogger : BaseLogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            File.WriteAllText(_filePath, $"{DateTime.Now:MM/dd/yyyy HH:mm:ss tt} " +
                $"{nameof(ClassName)}: {message}");
        }
    }
