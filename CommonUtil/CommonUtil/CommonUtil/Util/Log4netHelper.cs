using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using System.Diagnostics;
using System.Reflection;

namespace CommonUtil.Util
{
    public class Log4netHelper
    {
        private static ILog logger = log4net.LogManager.GetLogger("myLogger");
        public static void Info(string msg)
        {
            logger.Info(msg);
        }
        public static void Error(string msg)
        {
            logger.Error(msg);
        }
        public static void RecordException(Exception e)
        {
            StackTrace stackTrace = new StackTrace(true);
            MethodBase invoker = stackTrace.GetFrame(1).GetMethod();
            string message = string.Format("{0}异常：\r\n{1}", invoker.Name, e.ToString());
            Error(message);
        }
    }
}
