using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Util
{
    public static class EnumUtil
    {
        public static string ToDescription<T>(this T myEnum)
        {
            Type type = typeof(T);
            FieldInfo info = type.GetField(myEnum.ToString());
            DescriptionAttribute descriptionAttribute = info.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
            if (descriptionAttribute != null)
                return descriptionAttribute.Description;
            else
                return type.ToString();
        }
    }
}
