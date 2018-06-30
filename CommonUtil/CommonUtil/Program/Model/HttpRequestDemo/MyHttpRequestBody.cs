using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model.HttpRequestDemo
{
    public class MyHttpRequestBody
    {
        public string requestID { get; set; }
        public string scenarioID { get; set; }
        public string channel { get; set; }
        public string version { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string operatorID { get; set; }
        public bool pricing { get; set; }
        public MatchingModel matchingModel { get; set; }

        public class MatchingModel
        {
            public string flightNo { get; set; }
            public string actualCarrier { get; set; }
            public string departCity { get; set; }
            public string arriveCity { get; set; }
            public string cabin { get; set; }
            public DateTime departDate { get; set; }

            public MatchingModel()
            {
                flightNo = "xxx";
                actualCarrier = "xxx";
                departCity = "xxx";
                arriveCity = "xxx";
                cabin = "x";
                departDate = Convert.ToDateTime("2018-08-30");
            }
        }

        public MyHttpRequestBody()
        {
            requestID = "xxx";
            scenarioID = "xxx";
            channel = "xxx";
            version = "1.0";
            operatorID = "PC";
            pricing = true;
            matchingModel = new MatchingModel();
        }
    }
}
