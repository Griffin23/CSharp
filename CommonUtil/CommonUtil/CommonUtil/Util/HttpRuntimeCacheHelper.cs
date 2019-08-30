using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonUtil.Util
{
    public class HttpRuntimeCacheHelper
    {
        public static void SetAbsoluteExpirationCache(string key, object value, double milliSeconds)
        {
            HttpRuntime.Cache.Insert(key, value, null, DateTime.UtcNow.AddMilliseconds(milliSeconds),
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.Normal, null);
        }

        public static void SetSlidingExpirationCache(string key, object value, double milliSeconds)
        {
            HttpRuntime.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                TimeSpan.FromMilliseconds(milliSeconds),
                System.Web.Caching.CacheItemPriority.Normal, null);
        }

        public static object GetCache(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public static void removeCache(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}
