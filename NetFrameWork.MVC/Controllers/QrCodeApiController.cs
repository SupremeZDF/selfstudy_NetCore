using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using System.IO;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Net.Cache;
using System.Drawing.Imaging;
using System.Web.WebPages;
using System.Web.WebSockets;
using System.Net.Sockets;
using NetFrameWork.MVC.Models;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using System.Web;
using System.Threading.Tasks;
using System.Net;

namespace NetFrameWork.MVC.Controllers
{
    public class QrCodeApiController : ApiController
    {
        [HttpGet]
        public  HttpResponseMessage WebSocket()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                Handler handler = new Handler();
                HttpContext.Current.AcceptWebSocketRequest(handler.Webcoket_Request);
            }
            // return ;
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        public async Task ccc(AspNetWebSocketContext s) 
        {
        
        }

        [HttpGet]
        public void Name() 
        {

        }
    }
}
