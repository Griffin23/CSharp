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

        public static string GetFormDataPostResponseStr(string url, Dictionary<string, string> reqParamsDict)
        {
            RestClient restClient = new RestClient();
            var restRequest = new RestRequest(url, Method.POST);
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
                Log4netHelper.Error("GetFormDataPostResponseStr异常：url=" + url + ", reqParamsDict=" + reqParamsDict.ToString()
                    + "\r\nException：" + e.ToString());
                throw e;
            }
        }

        public static string GetJsonPostResponseStr(string url, Dictionary<string, string> headersDict, string reqJsonStr)
        {
            RestClient restClient = new RestClient(url);
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            foreach (var header in headersDict)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
            restRequest.AddParameter("application/json", reqJsonStr, ParameterType.RequestBody);
            try
            {
                var response = restClient.Execute(restRequest);
                return response.Content;
            }
            catch (Exception e)
            {
                Log4netHelper.Error("GetJsonPostRespnseStr异常：url=" + url + "headersDict=" + headersDict.ToString() 
                    + ", reqJsonStr=" + reqJsonStr + "\r\nException：" + e.ToString());
                throw e;
            }
        }

    }
}
