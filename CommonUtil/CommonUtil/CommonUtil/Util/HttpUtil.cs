using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public class HttpUtil
    {
        /// <summary>
        /// 获取get请求结果（string）
        /// </summary>
        /// <param name="queryUrl"></param>
        /// <returns></returns>
        public static string GetGetResponseStr(string queryUrl, object reqParamsObj = null, object headerObj = null, int timeoutMs = 10000)
        {
            RestClient restClient = new RestClient();
            var restRequest = new RestRequest(queryUrl, Method.GET);
            restRequest.Timeout = timeoutMs;
            try
            {
                Dictionary<string, string> headerDict = ModelHelper.GetDictionaryFromModel<object>(headerObj);
                foreach (var header in headerDict)
                {
                    restRequest.AddHeader(header.Key, header.Value);
                }
                Dictionary<string, string> reqParams = ModelHelper.GetDictionaryFromModel<object>(reqParamsObj);
                foreach (var param in reqParams)
                {
                    restRequest.AddParameter(param.Key, param.Value);
                }
                var response = restClient.Execute(restRequest);
                return response.Content;
            }
            catch (Exception e)
            {
                Log4netHelper.Error(string.Format("{0}异常：\r\nqueryUrl：{1}\r\nException：{2}", MethodBase.GetCurrentMethod().Name,
                    queryUrl, e.ToString()));
                throw e;
            }
        }

        public static string GetPostResponseStr(string url, object reqParamsObj, bool isJsonPost, object headerObj = null, int timeoutMs = 10000)
        {
            RestClient restClient = new RestClient();
            var restRequest = new RestRequest(url, Method.POST);
            restRequest.Timeout = timeoutMs;
            try
            {
                Dictionary<string, string> headerDict = ModelHelper.GetDictionaryFromModel<object>(headerObj);
                foreach (var header in headerDict)
                {
                    restRequest.AddHeader(header.Key, header.Value);
                }
                if (isJsonPost)
                {
                    restRequest.AddParameter("application/json", JsonHelper.GetJsonFromObject(reqParamsObj), ParameterType.RequestBody);
                }
                else
                {
                    Dictionary<string, string> reqParams = ModelHelper.GetDictionaryFromModel<object>(reqParamsObj);
                    foreach (var param in reqParams)
                    {
                        restRequest.AddParameter(param.Key, param.Value);
                    }
                }
                var response = restClient.Execute(restRequest);
                return response.Content;
            }
            catch (Exception e)
            {
                Log4netHelper.Error(string.Format("{0}异常：\r\nqueryUrl：{1}\r\nPostParam：{2}\r\nException：{3}", MethodBase.GetCurrentMethod().Name,
                    url, JsonHelper.GetJsonFromObject(reqParamsObj), e.ToString()));
                throw e;
            }
        }
    }
}
