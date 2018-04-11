using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidateCodeImgDemo.Models.Enum
{
    public enum ReturnCodeEnum
    {
        请求成功 = 200,
        系统内部错误 = 500,
        图形验证码错误 = 510,
        图形验证码失效 = 511
    }
}