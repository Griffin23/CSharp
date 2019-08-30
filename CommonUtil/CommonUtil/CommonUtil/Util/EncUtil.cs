using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public class EncUtil
    {

        private const string ENC_EX_RESULT = "ENC_EX_RESULT";

        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5Enc(string input)
        {
            string result = "";
            if (input != null)
            {
                byte[] data = Encoding.GetEncoding("GB2312").GetBytes(input);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] OutBytes = md5.ComputeHash(data);
                for (int i = 0; i < OutBytes.Length; i++)
                {
                    result += OutBytes[i].ToString("x2");
                }
            }
            return result.ToLower();
        }

        // 133****1234
        public static string GetEncPhoneNo(string phoneNo)
        {
            try
            {
                return GetEncResult(phoneNo, 3, 4);
            }
            catch (Exception e)
            {
                Log4netHelper.RecordException(e);
                return ENC_EX_RESULT;
            }
        }

        private static string GetEncResult(string initStr, int encStartIndex, int encLength)
        {
            if (string.IsNullOrEmpty(initStr) || encLength <= 0)
            {
                return initStr;
            }
            int len = initStr.Length;
            if (encStartIndex < 0)
            {
                if (Math.Abs(encStartIndex) > len)
                {
                    return initStr;
                }
                encStartIndex = len + encStartIndex;
            }
            if (encStartIndex >= len)
            {
                return initStr;
            }
            if (encLength >= len - encStartIndex)
            {
                return initStr.Substring(0, encStartIndex) + GetStarString(len - encStartIndex);
            }
            return initStr.Substring(0, encStartIndex) + GetStarString(encLength) + initStr.Substring(encStartIndex + encLength);
        }

        private static string GetStarString(int startCount)
        {
            string result = string.Empty;
            for (int i = 0; i < startCount; i++)
            {
                result += "*";
            }
            return result;
        }

    }
}
