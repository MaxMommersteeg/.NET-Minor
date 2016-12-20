using Case2.MaRoWo.Logger.Entities;

namespace Case2.MaRoWo.Logger.Services
{
    public interface ILogService
    {
        void Log(LogMessage logMessage);
        void LogException(LogMessage logMessage);
    }
}
