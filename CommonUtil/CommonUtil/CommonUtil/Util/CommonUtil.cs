using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonUtil.Util
{
    public class CommonUtil
    {
        // 获取客户端IP
        public static string GetClientIp()
        {
            string ip = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP.

            }
            else // not using proxy or can't get the Client IP
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); // While it can't get the Client IP, it will return proxy IP.
            }
            return ip;
        }
    }
}
