using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public class ModelHelper
    {
        /// <summary>
        /// 遍历实体类属性，读取key value，封装为Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDictionaryFromModel<T>(T model)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Type t = model.GetType();
            System.Reflection.PropertyInfo[] PropertyList = t.GetProperties();
            foreach (System.Reflection.PropertyInfo item in PropertyList)
            {
                var value = item.GetValue(model, null);
                if (value != null)
                {
                    result.Add(item.Name, value.ToString());
                }
            }
            return result;
        }
    }
}
