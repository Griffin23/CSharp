using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model.HttpRequestDemo
{
    public class MyHttpRequestHeader
    {
        public string plat { get; set; }
        public string lang { get; set; }

        public MyHttpRequestHeader()
        {
            plat = "PCWEB";
            lang = "zh_CN";
        }
    }
}
