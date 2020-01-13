using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Services.Interfaces;
using System.Text.Json;

namespace Kibol_Alert.Services
{
    public class BaseService
    {
        protected Kibol_AlertContext Context { get; }
        private readonly ILoggerService _logger;

        public BaseService(Kibol_AlertContext context, ILoggerService logger)
        {
            Context = context;
            _logger = logger;
        }

        public void AddLog<T>(T data, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            var log = new Log()
            {
                MethodName = memberName,
                Message = JsonSerializer.Serialize(data),
            };

            Context.Logs.Add(log);
            Context.SaveChangesAsync();
        }

    }
}