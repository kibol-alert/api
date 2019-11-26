using Kibol_Alert.Database;
using Kibol_Alert.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kibol_Alert.Services
{
    public class BaseService
    {
        protected Kibol_AlertContext Context { get; }

        public BaseService(Kibol_AlertContext context)
        {
            Context = context;
        }

    }
}
