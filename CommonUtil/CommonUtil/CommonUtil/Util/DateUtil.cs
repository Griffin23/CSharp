using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public class DateUtil
    {
        /// <summary>
        /// 获取当前时间戳（秒）
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentTimestamp()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
