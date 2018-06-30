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
            Dictionary<string, string> headerDict = ModelHelper.GetDictionaryFromModel<MyHttpRequestHeader>(header);
            MyHttpRequestBody body = new MyHttpRequestBody();
            string reqJsonStr = JsonHelper.GetJsonFromObject(body);
            return HttpRequestHelper.GetJsonPostResponseStr(url, headerDict, reqJsonStr);
        }
    }
}
