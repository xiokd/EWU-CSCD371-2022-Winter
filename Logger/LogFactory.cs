namespace Logger;

    public class LogFactory
    {
        private string _filePath;
        private string _className;

        public BaseLogger CreateLogger(string className)
        {
            _className = className;
            return new FileLogger(_filePath);
        }

        public void ConfigureFileLogger(string filePath)
        {
            _filePath = filePath;
        }
    }
