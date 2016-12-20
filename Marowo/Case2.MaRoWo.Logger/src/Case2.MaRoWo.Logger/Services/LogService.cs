using System;
using Case2.MaRoWo.Logger.Entities;
using System.IO;

namespace Case2.MaRoWo.Logger.Services
{
    public class LogService : ILogService
    {
        private const string MESSAGE_TYPE_ERROR = "ERROR";
        private readonly DirectoryInfo _directoryInfo;

        private object _writeLock = new object();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directoryInfo"></param>
        public LogService(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException();
            }
            _directoryInfo = directoryInfo;
            Initialize();
        }

        /// <summary>
        /// Logging for normal messages
        /// </summary>
        /// <param name="logMessage"></param>
        public void Log(LogMessage logMessage)
        {
            if (logMessage == null)
            {
                throw new ArgumentNullException(nameof(logMessage));
            }
            WriteLogToFile(logMessage.ToString());
        }

        /// <summary>
        /// Logging for exception messages
        /// </summary>
        /// <param name="logMessage"></param>
        public void LogException(LogMessage logMessage)
        {
            if (logMessage == null)
            {
                throw new ArgumentNullException(nameof(logMessage));
            }
            logMessage.MessageType = MESSAGE_TYPE_ERROR;
            WriteLogToFile(logMessage.ToString());
        }

        /// <summary>
        /// Initialize LogService
        /// </summary>
        private void Initialize()
        {
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }
        }

        /// <summary>
        /// Writing to Log File
        /// </summary>
        /// <param name="logMessage"></param>
        private void WriteLogToFile(string logMessage)
        {
            string currentLogFile = GetLogFileNameAndExtension();
            string fullLogFilePath = Path.Combine(_directoryInfo.FullName, currentLogFile);
            // Check if log file exists, create if not
            using(var stream = File.Open(fullLogFilePath, FileMode.Append, FileAccess.Write))
            {
                lock (_writeLock)
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(logMessage);
                        writer.Flush();
                    }
                }
         
            }
        }

        /// <summary>
        /// GetLogFileNameAndExtension
        /// </summary>
        /// <returns></returns>
        private string GetLogFileNameAndExtension()
        {
            var today = DateTime.UtcNow.Date;
            return $"{today.Year}{today.Month}{today.Day}_log.txt";
        }
    }
}
