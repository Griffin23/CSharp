using CommonUtil.Util;
using Program.Model.HttpRequestDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class HttpRequestDemo
    {
        public static string GetJsonPostResponseStr()
        {
            string url = "xxxx";
            MyHttpRequestHeader header = new MyHttpRequestHeader();
            MyHttpRequestBody body = new MyHttpRequestBody();
            return HttpUtil.GetGetResponseStr(url, body, header);
        }
    }
}
