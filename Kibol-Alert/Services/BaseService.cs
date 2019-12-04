using Kibol_Alert.Database;

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
