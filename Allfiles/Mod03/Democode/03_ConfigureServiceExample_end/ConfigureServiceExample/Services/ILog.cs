using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServiceExample.Services
{
    public interface ILog
    {
        void WriteLog(string logData);
    }
}
