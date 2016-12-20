using FileSystemGarbageCollector;

namespace FileAndStreams
{
    public class ConsoleReaderMock : IConsoleReader
    {
        public string Path { get; set; }

        public ConsoleReaderMock(string path)
        {
            Path = path;
        }

        public string ReceiveInput()
        {
            return Path;
        }
    }
}
