using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public class RandomCodeGenerator
    {
        public static string GetRandomCode(int count)
        {
            string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string validatecode = "";
            Random rd = new Random();
            for (int i = 0; i < count; i++)
            {
                validatecode += str.Substring(rd.Next(0, str.Length), 1);
            }
            return validatecode;
        }
    }
}
