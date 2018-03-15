using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Log4netDemo.Util;

namespace Log4netDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4netHelper.Info("Test info log");
            Log4netHelper.Error("Test error log");
        }
    }
}
