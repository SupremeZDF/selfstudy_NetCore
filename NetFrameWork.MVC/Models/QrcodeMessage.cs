using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Threading;
using System.Net.WebSockets;
using System.Web.Services.Description;
using System.Web.WebSockets;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Text;

namespace NetFrameWork.MVC.Models
{
    public class QrcodeMessage
    {
        public QrcodeMessage(DateTime _dateTime, ArraySegment<byte> _array)
        {
            dateTime = _dateTime;
            arraySegment = _array;
        }

        public DateTime dateTime { get; set; }

        public ArraySegment<byte> arraySegment { get; set; }
    }

    public class Qrcode
    {
        //程序池
        public static Dictionary<string, WebSocket> qrCodeList = new System.Collections.Generic.Dictionary<string, WebSocket>();

        public void IsSM(HttpContext context)
        {
            var qrID = context.Request.QueryString["rqID"];
            if (qrCodeList.ContainsKey(qrID))
            {
                if (qrCodeList[qrID].State == WebSocketState.Open)
                {
                    var dd = Encoding.UTF8.GetBytes("2");
                    qrCodeList[qrID].SendAsync(new ArraySegment<byte>(dd), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        /// <summary>
        /// 二维码
        /// </summary>
        /// <returns></returns>
        public async Task Qrcode_Request(AspNetWebSocketContext aspNetWebSocketContext)
        {
            //获取二维码ID
            var qrID = "";
            qrID = aspNetWebSocketContext.QueryString["rqID"].ToString();
            WebSocket webSocket = aspNetWebSocketContext.WebSocket;
            //判断socket是否存在
            if (!qrCodeList.ContainsKey(qrID))
            {
                qrCodeList.Add(qrID, webSocket);
            }
            else
            {
                if (qrCodeList[qrID] != webSocket)
                {
                    //如果不同对象，则更换
                    qrCodeList[qrID] = webSocket;
                }
            }
            while (true)
            {
                try
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
                    //var cc=webSocket.ReceiveAsync
                    WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                    //消息短接处理
                    if (webSocket.State != WebSocketState.Open)
                    {
                        if (qrCodeList.ContainsKey(qrID))
                            qrCodeList.Remove(qrID);
                        break;
                    }
                    var message = Encoding.UTF8.GetString(buffer.Array, 0, receiveResult.Count);
                    if (message != "")
                    {
                        buffer = new ArraySegment<byte>(qrCodes(message));
                    }
                    await webSocket.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    var xx = ex.Message;
                }

            }
        }

        public byte[] qrCodes(string qrid)
        {
            int qrCodeScale = 12;   //尺寸4-15
            int qrCodeVersion = 0;  //复杂级别3-12
            string qrCodeErrorCorrect = "H"; // 容错量"H","L","M","Q"
            string enCodeString = "https://192.168.131.211:44397/api/QrCodeApi/Qrcode?rqID=" + qrid;   //二维码信息
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

            return ccc;

            //byte[] by = new byte[memoryStream.Length];
            //memoryStream.Read(by, 0, (int)memoryStream.Length);
            //memoryStream.Position = 0;
            //memoryStream.Close();
            //解析二维码
            //QRCodeDecoder decoder = new QRCodeDecoder();
            //string decodeString = decoder.decode(new QRCodeBitmapImage(new Bitmap(bitmap)));
            //string fileName = qrCodeScale + "_" + qrCodeVersion + "_" + qrCodeErrorCorrect;
            //string filePath = AppDomain.CurrentDomain.BaseDirectory;
            //string file_Path = "D:\\ExcelServer\\Qrcode\\" + fileName +DateTime.Now.ToFileTime().ToString().Replace(" ","")+ ".jpg";
            //var aa = "D:\\ExcelServer\\Qrcode\\";
            //try
            //{
            //    if (!Directory.Exists(file_Path))
            //    {
            //        Directory.CreateDirectory(aa);
            //    }
            //bitmap.Save(file_Path);
            //FileStream fileStream = new FileStream(file_Path,FileMode.OpenOrCreate,FileAccess.Read);
            //HttpContext.Response.Clear();
            //HttpContext.Response.Buffer = true;
            //HttpContext.Response.ContentEncoding = Encoding.UTF8;
            //HttpContext.Response.Charset = "UTF-8";
            //HttpContext.Response.AddHeader("Content-Disposition", string.Format(@"attachment;filename=""{0}""", HttpUtility.UrlEncode(fileName+".jpg")));
            //HttpContext.Response.ContentType = "application/octet-stream";
            //HttpContext.Response.AddHeader("Content-Length",ddd.Length.ToString());
            //HttpContext.Response.WriteBinary(ddd);
            //HttpContext.Response.Filter.Close();
            //    //HttpContext.Response.Flush();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

    }
}