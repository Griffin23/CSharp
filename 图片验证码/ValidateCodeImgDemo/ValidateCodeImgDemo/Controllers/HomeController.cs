using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

using ValidateCodeImgDemo.Models.Enum;

namespace ValidateCodeImgDemo.Controllers
{
    public class HomeController : Controller
    {
        private static string SESSION_VALIDATECODE = "VALIDATECODE";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetValidateCodeImg()
        {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            string validateNum = GetValidateCode(5);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (validateNum == null || validateNum.Trim() == string.Empty)
                return null;
            //生成BitMap图像
            //System.Drawing.Bitmap image = new System.Drawing.Bitmap(validateNum.Length * 12 + 12, 22);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(100, 40);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景
                g.Clear(Color.White);
                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 15, 10);
                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));

                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //将图像保存到指定流
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Session[SESSION_VALIDATECODE] = validateNum;
                return File(ms.ToArray(), "image/Gif");
                //Response.ClearContent();
                //Response.ContentType = "image/Gif";
                //Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public string GetValidateCode(int count)
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

        private bool ValidateCode(string validateCode)
        {
            string session_validateCode = (string)Session[SESSION_VALIDATECODE];
            if (session_validateCode == null)
                throw new Exception();
            if (session_validateCode == validateCode.ToUpper())
            {
                // 保证图形验证码只验证一次
                Session.Remove(SESSION_VALIDATECODE);
                return true;
            }
            return false;
        }

        public JsonResult ValidateCodeFromClient(string validateCode)
        {
            try
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                if (!ValidateCode(validateCode))
                    return Json(new { result = false, code = ReturnCodeEnum.图形验证码错误, info = "图形验证码错误，请重新输入" }, JsonRequestBehavior.AllowGet);
                return Json(new { result = true, code = ReturnCodeEnum.请求成功, info = "验证通过" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { result = false, code = ReturnCodeEnum.图形验证码失效, info = "请点击刷新图形验证码" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
