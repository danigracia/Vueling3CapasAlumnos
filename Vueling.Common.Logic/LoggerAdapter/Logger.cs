using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.LoggerAdapter
{
    public class Logger : ITargetAdapterForLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool isInfoEnabled = true;
        private bool isWarnEnabled = true;
        private bool isDebugEnabled = true;
        private bool isErrorEnabled = true;
        private bool isFatalEnabled = true;

        public TimeSpan ExecutionTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Counter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public Logger()
        {
            this.isInfoEnabled = log.IsInfoEnabled;
            this.isWarnEnabled = log.IsWarnEnabled;
            this.isDebugEnabled = log.IsDebugEnabled;
            this.isErrorEnabled = log.IsErrorEnabled;
            this.isFatalEnabled = log.IsFatalEnabled;
        }

        #region logslevels

        public void Info(string message)
        {
            if (isInfoEnabled)
                log.Info(message);            
        }
        public void Info(Student st)
        {
            if (isInfoEnabled)
            {
                foreach (PropertyInfo prop in typeof(Student).GetProperties())
                {
                    log.Info(st.GetType().ToString() + prop.Name + ": " + prop.GetValue(st));
                }
            }
        }
        /*public void Info(string format, params object[] args)
        {
            throw new NotImplementedException();
        }*/
        public void Debug(string message)
        {
            if (isDebugEnabled)
                log.Debug(message);
        }
        public void Debug(Student st)
        {
            if (isInfoEnabled)
            {
                foreach (PropertyInfo prop in typeof(Student).GetProperties())
                {
                    log.Info(st.GetType().ToString() + prop.Name + ": " + prop.GetValue(st));
                }
            }
        }
        public void Warn(string message)
        {
            if (isWarnEnabled)
                log.Warn(message);
        }
        public void Error(string message)
        {
            if (isErrorEnabled)
                log.Error(message);
        }
        public void Fatal(string message)
        {
            if (isFatalEnabled)
                log.Fatal(message);
        }
        
        #endregion


        #region exceptions
        public void Exception(Exception exception, string message)
        {
            if (isErrorEnabled)
                log.Error(message, exception);
        }
        public void Exception(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
        public void EmailException(string message)
        {
            SmtpClient client = new SmtpClient();
            client.Send("enric.pedros@atmira.com", "enric.pedros@atmira.com", "Error", message);
        }
        #endregion


    }
}
