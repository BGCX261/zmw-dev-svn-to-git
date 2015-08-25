using System;
using log4net;

namespace zmw.dev.utils
{
    public class Loggers
    {

        private static readonly ILog Message = LogManager.GetLogger("MessageLogger");
        private static readonly ILog Access = LogManager.GetLogger("AccessLogger");

        public static void AccessLog()
        {
            Access.Info("");
        }



        public static void Debug(string message)
        {
            if (Message.IsDebugEnabled)
            {
                Message.Debug(message);
            }
        }
        public static void Debug(Exception ex1)
        {
            if (Message.IsDebugEnabled)
            {
                Message.Debug(ex1.Message + "/r/n" + ex1.Source + "/r/n" + ex1.TargetSite + "/r/n" + ex1.StackTrace);
            }
        }
        public static void Error(string message)
        {
            if (Message.IsErrorEnabled)
            {
                Message.Error(message);
            }
        }
        public static void Fatal(string message)
        {

            if (Message.IsFatalEnabled)
            {
                Message.Fatal(message);
            }
        }
        public static void Info(string message)
        {
            if (Message.IsInfoEnabled)
            {
                Message.Info(message);
            }
        }

        public static void Warn(string message)
        {
            if (Message.IsWarnEnabled)
            {
                Message.Warn(message);
            }
        }

    }
}