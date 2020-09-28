using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;

namespace Mvc.Controllers
{
    public class qrCode : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void qrCodes()
        {
            int qrCodeScale = 10;   //尺寸4-15
            int qrCodeVersion = 6;  //复杂级别3-12
            string qrCodeErrorCorrect = "L"; // 容错量"H","L","M","Q"
            string enCodeString = "http://www.baidu.com";   //二维码信息
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;  //编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qRCodeEncoder.QRCodeScale = qrCodeScale;
            qRCodeEncoder.QRCodeVersion = qrCodeVersion;
            switch (qrCodeErrorCorrect)
            {
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
            //    System.Drawin
            //    qRCodeEncoder.Encode();
            //}
        }
    }
}
