using Kibol_Alert.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
