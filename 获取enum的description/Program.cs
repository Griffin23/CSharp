using System;
using MyPro.Utils.Enum;
using System.ComponentModel;

namespace MyPro
{
    class Program
    {
        private enum colors {
            [Description("red color")]
            red,
            [Description("yellow color")]
            yellow,
            [Description("blue color")]
            blue
        }
        static void Main(string[] args)
        {
            Console.WriteLine(colors.red.ToDescription());
            string s = "1111";
            Console.WriteLine(s.ToDescription());
        }
    }
} 