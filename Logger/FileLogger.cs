using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger;

    public class FileLogger : BaseLogger
    {
        private Path _path;

    public string className { get; set; } = "FileLogger";

        public FileLogger(Path path)
        {
            _path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string log = DateTime.Now.ToString("MM'/'dd'/'yyyy HH':'mm':'ss tt") + className;
            File.WriteAllText(_path, text);
        }
    }
