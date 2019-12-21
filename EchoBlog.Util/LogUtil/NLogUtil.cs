using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Util.LogUtil
{
    /// <summary>
    /// Nlog 日志封装类
    /// </summary>
    public class NLogUtil
    {
        private static readonly Logger logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

        #region Info 级别日志

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Info(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public static void Info(LogMessageGenerator messageFunc)
        {
            logger.Info(messageFunc);
        }

        public static void Info(Exception exception, LogMessageGenerator messageFunc)
        {
            logger.Info(exception, messageFunc);
        }

        #endregion


        #region Error 级别日志

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Error(Exception exception, string message)
        {
            logger.Error(exception, message);
        }

        public static void Error(LogMessageGenerator messageFunc)
        {
            logger.Error(messageFunc);
        }

        public static void Error(Exception exception, LogMessageGenerator messageFunc)
        {
            logger.Error(exception, messageFunc);
        }

        #endregion
    }
}
