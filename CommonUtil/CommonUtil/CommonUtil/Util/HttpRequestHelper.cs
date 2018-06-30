using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public class HttpRequestHelper
    {
        public static string GetGetResponseStr(string url)
        {
            RestClient restClient = new RestClient();
            var restRequest = new RestRequest(url, Method.GET);
            try
            {
                var response = restClient.Execute(restRequest);
                return response.Content;
            }
            catch (Exception e)
            {
                Log4netHelper.Error("GetGetResponseStr异常：url=" + url + "\r\nException：" + e.ToString());
                throw e;
            }
        }

        public static string GetFormDataPostResponseStr(string url, object reqParamsObj)
        {
            RestClient restClient = new RestClient();
            var restRequest = new RestRequest(url, Method.POST);
            Dictionary<string, string> reqParamsDict = ModelHelper.GetDictionaryFromModel<object>(reqParamsObj);
            foreach (var param in reqParamsDict)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }
            try
            {
                var response = restClient.Execute(restRequest);
                return response.Content;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetJsonPostResponseStr(string url, object headerObj, object reqParams)
        {
            RestClient restClient = new RestClient(url);
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            Dictionary<string, string> headersDict = ModelHelper.GetDictionaryFromModel<object>(headerObj);
            foreach (var header in headersDict)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
            string reqJsonStr = JsonHelper.GetJsonFromObject(reqParams);
            restRequest.AddParameter("application/json", reqJsonStr, ParameterType.RequestBody);
            try
            {
                var response = restClient.Execute(restRequest);
                return response.Content;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
