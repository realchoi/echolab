using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Infrastructures.Core.Utils
{
    public class LogUtil
    {
        private static readonly Logger _logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();


        public static void Debug(string message) => _logger.Debug(message);

        public static void Debug(Exception exception, string message) => _logger.Debug(exception, message);


        public static void Info(string message) => _logger.Info(message);

        public static void Info(Exception exception, string message) => _logger.Info(exception, message);


        public static void Error(string message) => _logger.Error(message);

        public static void Error(Exception exception, string message) => _logger.Error(exception, message);
    }
}
