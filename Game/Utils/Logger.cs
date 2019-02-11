using System;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Game.Utils
{
    public class Logger
    {
        protected static log4net.ILog log;
        private static Logger _log;
        /// <summary>
        /// 获取默认日志记录器
        /// </summary>
        public static Logger Default { get { return _log ?? (_log = new Logger()); } }
        /// <summary>
        /// 构造函数
        /// </summary>
        public Logger()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

                // log = log4net.LogManager.GetCurrentLoggers().FirstOrDefault();
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.Write(ex.StackTrace);
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Logger(string name)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                log = log4net.LogManager.GetLogger(name);

            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.Write(ex.StackTrace);
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type"></param>
        public Logger(Type type)
        {
            try
            {
                log = log4net.LogManager.GetLogger(type);
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.Write(ex.StackTrace);
            }
        }

        #region Debug 调试日志

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            if (log != null) log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            if (log != null) log.Debug(message, exception);
        }

        public void DebugFormat(string format, object arg0)
        {
            if (log != null) log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (log != null) log.DebugFormat(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.DebugFormat(provider, format, args);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.DebugFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Error 错误日志

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            if (log != null) log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            if (log != null) log.Error(message, exception);
        }

        public void ErrorFormat(string format, object arg0)
        {
            if (log != null) log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (log != null) log.ErrorFormat(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.ErrorFormat(provider, format, args);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.ErrorFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Fatal 致命的,毁灭性的日志

        /// <summary>
        /// 致命的,毁灭性的日志
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            if (log != null) log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            if (log != null) log.Fatal(message, exception);
        }

        public void FatalFormat(string format, object arg0)
        {
            if (log != null) log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (log != null) log.FatalFormat(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.FatalFormat(provider, format, args);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.FatalFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Info 信息日志

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            if (log != null) log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            if (log != null) log.Info(message, exception);
        }

        public void InfoFormat(string format, object arg0)
        {
            if (log != null) log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (log != null) log.InfoFormat(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.InfoFormat(provider, format, args);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.InfoFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Warning 警告,注意,通知日志

        /// <summary>
        /// 警告,注意,通知日志
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            if (log != null) log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            if (log != null) log.Warn(message, exception);
        }

        public void WarnFormat(string format, object arg0)
        {
            if (log != null) log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (log != null) log.WarnFormat(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.WarnFormat(provider, format, args);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.WarnFormat(format, arg0, arg1, arg2);
        }

        #endregion
    }
}
