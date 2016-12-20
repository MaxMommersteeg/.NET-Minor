using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemGarbageCollector
{
    public class HomeController
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;

        public string FolderPath { get; private set; }

        public HomeController(IConsoleReader consoleReader, IConsoleWriter consoleWriter)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
        }

        public string RequestPath()
        {
            _consoleWriter.WriteLine("Geef solution path:");
            FolderPath = _consoleReader.ReceiveInput();

            if(!PathIsRooted(FolderPath))
            {
                throw new NotRootedPathException();
            }

            if(!ExistingDirectory(FolderPath))
            {
                throw new NonExistingDirectoryException();
            }

            return FolderPath;
        }

        public bool PathIsRooted(string path)
        {
            return Path.IsPathRooted(path);
        }

        public bool ExistingDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public IEnumerable<DirectoryInfo> GetVsDirectory(string root)
        {
            if(!ExistingDirectory(root))
            {
                throw new NonExistingDirectoryException();
            }

            var foundVsDirectories = new List<DirectoryInfo>();

            DirectoryInfo di = new DirectoryInfo(root);
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                foundVsDirectories.Add(dir);
            }
            return foundVsDirectories;
        }
    }
}