using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Services.Interfaces;

namespace Kibol_Alert.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly Kibol_AlertContext Context;
        public LoggerService(Kibol_AlertContext context)
        {
            Context = context;
        }

        public void AddLog(Log log)
        {
            Context.Logs.Add(log);
            Context.SaveChangesAsync();
        }
    }
}
