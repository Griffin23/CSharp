using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace CommonUtil.Util
{
    public class Log4netHelper
    {
        public static void Info(string msg)
        {
            ILog logger = log4net.LogManager.GetLogger("InfoLog");
            logger.Info(msg);
        }
        public static void Error(string msg)
        {
            ILog logger = log4net.LogManager.GetLogger("ErrorLog");
            logger.Error(msg);
        }
    }
}
