using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.LoggerAdapter
{
    public interface ITargetAdapterForLogger
    {
        TimeSpan ExecutionTime { get; set; }
        int Counter { get; set; }

        void Info(string message);
        //void Info(string format, params object[] args);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Exception(Exception exception, string message);
        void EmailException(string message);
    }
}
