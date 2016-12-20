using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using System.IO;

namespace Case2.MaRoWo.Logger.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LogService(new DirectoryInfo(@"C:\Test"));
            logger.LogException(new LogMessage("Testing Message Exception"));
            logger.Log(new LogMessage("Testing Message"));
            logger.Log(new LogMessage("Testing Message"));
            logger.Log(new LogMessage("Testing Message"));
            logger.Log(new LogMessage("Testing Message"));
        }
    }
}
