using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.IO;
using System.Data;
using ThoughtWorks.QRCode.Codec.Data;
using System.Net.Http;
using System.Text;
using System.Net.Cache;
using System.Drawing.Imaging;
using System.Web.WebPages;
using System.Web.WebSockets;
using System.Net.Sockets;
using NetFrameWork.MVC.Models;

namespace NetFrameWork.MVC.Controllers
{
    public class qrCodeController : Controller
    {

        /// <summary>
        /// 代码提交
        /// </summary>
        //public void AA() 
        //{
        //    var allsockets=new List<IWebSocketConnection>
        //}

        // GET: qrCode
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public void qrCodes()
        {
            int qrCodeScale = 12;   //尺寸4-15
            int qrCodeVersion = 0;  //复杂级别3-12
            string qrCodeErrorCorrect = "H"; // 容错量"H","L","M","Q"
            string enCodeString = "http://www.baidu.com";   //二维码信息
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;  //编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qRCodeEncoder.QRCodeScale = qrCodeScale;//大小(值越大生成的二维码图片像素越高)
            qRCodeEncoder.QRCodeVersion = qrCodeVersion; //版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            switch (qrCodeErrorCorrect) 
            {
                //错误效验、错误更正(有4个等级)
                case "H":
                    qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                    break;
                case "L":
                    qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    break;
                case "M":
                    qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    break;
                case "Q":
                    qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                    break;
            }
            Bitmap bitmap = qRCodeEncoder.Encode(enCodeString, System.Text.Encoding.GetEncoding("UTF-8"));

            Image image = bitmap;
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Bmp);
            memoryStream.Position = 0;
            var dd = memoryStream.Length;
            var ddd = new byte[dd];
            memoryStream.Read(ddd, 0, (int)dd);
            BinaryReader binary = new BinaryReader(memoryStream);
            var ccc = memoryStream.ToArray();
            //byte[] by = new byte[memoryStream.Length];
            //memoryStream.Read(by, 0, (int)memoryStream.Length);
            //memoryStream.Position = 0;
            //memoryStream.Close();
            //解析二维码
            //QRCodeDecoder decoder = new QRCodeDecoder();
            //string decodeString = decoder.decode(new QRCodeBitmapImage(new Bitmap(bitmap)));
            string fileName = qrCodeScale + "_" + qrCodeVersion + "_" + qrCodeErrorCorrect;
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            string file_Path = "D:\\ExcelServer\\Qrcode\\" + fileName +DateTime.Now.ToFileTime().ToString().Replace(" ","")+ ".jpg";
            var aa = "D:\\ExcelServer\\Qrcode\\";
            try
            {
                if (!Directory.Exists(file_Path))
                {
                    Directory.CreateDirectory(aa);
                }
                bitmap.Save(file_Path);
                //FileStream fileStream = new FileStream(file_Path,FileMode.OpenOrCreate,FileAccess.Read);
                HttpContext.Response.Clear();
                HttpContext.Response.Buffer = true;
                HttpContext.Response.ContentEncoding = Encoding.UTF8;
                HttpContext.Response.Charset = "UTF-8";
                HttpContext.Response.AddHeader("Content-Disposition", string.Format(@"attachment;filename=""{0}""", HttpUtility.UrlEncode(fileName+".jpg")));
                HttpContext.Response.ContentType = "application/octet-stream";
                HttpContext.Response.AddHeader("Content-Length",ddd.Length.ToString());
                HttpContext.Response.WriteBinary(ddd);
                HttpContext.Response.Filter.Close();
                HttpContext.Response.Flush();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// <summary>
        /// 用户请求
        /// </summary>
        public async void WebSocket() 
        {
            if (HttpContext.IsWebSocketRequest) 
            {
                Handler handler = new Handler();
                HttpContext.AcceptWebSocketRequest(handler.Webcoket_Request);
            }
        }

        public void cc() 
        {

            //int i = 10;
            //object obj = i;
            //int j = obj;
        }

        //public void SampleMethod(ref int i) { }
        //public void SampleMethod(out int i) { }
    }

    //class RefOutOverloadExample
    //{
    //    public void SampleMethod(int i) { }
    //    public void SampleMethod(out int i) { }
    //}
}