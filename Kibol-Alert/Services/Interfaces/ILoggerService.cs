using Kibol_Alert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services.Interfaces
{
    public interface ILoggerService
    {
        public void AddLog(Log log);
    }
}
