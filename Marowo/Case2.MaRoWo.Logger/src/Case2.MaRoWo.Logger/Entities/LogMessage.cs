using System;

namespace Case2.MaRoWo.Logger.Entities
{
    public class LogMessage
    {
        public LogMessage(string message)
        {
            Message = message;
            CreatedUtc = DateTime.UtcNow;
        }

        public LogMessage(string message, string stackTrace) : this(message)
        {
            StackTrace = stackTrace;
        }

        public DateTime CreatedUtc { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string MessageType { get; set; }

        public override string ToString()
        {
            if(string.IsNullOrWhiteSpace(MessageType))
            {
                return $"{CreatedUtc.ToString("dd-MM-yyyy HH:mm:ss")} | {Message} | {StackTrace}";
            }
            return $"{CreatedUtc.ToString("dd-MM-yyyy HH:mm:ss")} | {MessageType} | {Message} | {StackTrace}";
        }
    }
}
