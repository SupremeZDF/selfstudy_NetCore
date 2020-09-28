using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.WebSockets;
using System.Net.Sockets;
using System.IO;

namespace NetFrameWork.MVC.Models
{
    /// <summary>
    /// 离线消息
    /// </summary>
    public class MessageInfo
    {
        public MessageInfo(DateTime _msgtime, ArraySegment<byte> _msgContent)
        {
            string[] o = { "", "", "" };
            MsgTime = _msgtime;
            MsgContent = _msgContent;
        }
        public DateTime MsgTime { get; set; }

        public ArraySegment<byte> MsgContent { get; set; }
    }

    public class Handler
    {
        private static Dictionary<string, WebSocket> ConNect_Pool = new Dictionary<string, WebSocket>(); //用户连接池

        private static Dictionary<string, List<MessageInfo>> Message_Pool = new Dictionary<string, List<MessageInfo>>(); //离线消息池

        /// <summary>
        /// web socket 请求
        /// </summary>
        /// <returns></returns>
        public async Task Webcoket_Request(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            var dd = context.RequestUri;
            string user = context.QueryString["userID"].ToString();
            try
            {
                #region  用户添加连接池
                //第一次open  添加到连接池中
                if (!ConNect_Pool.ContainsKey(user))
                {
                    ConNect_Pool.Add(user, socket); //不存在添加
                }
                else
                {
                    if (socket != ConNect_Pool[user]) //当前对象不一致，更新
                    {
                        ConNect_Pool[user] = socket;
                    }
                }
                #endregion

                #region 离线消息处理
                if (Message_Pool.ContainsKey(user))
                {
                    List<MessageInfo> msag = Message_Pool[user];
                    foreach (MessageInfo info in msag)
                    {
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        //发送消息
                        await socket.SendAsync(info.MsgContent, WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
                        //Task.Run();
                    }
                    Message_Pool.Remove(user);  //移除离线消息
                }
                #endregion
                string descUser = string.Empty;  //目的用户
                while (true)
                {
                    if (socket.State == WebSocketState.Open)
                    {
                        ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
                        //连接对象开始监听（每个客户端与服务器保存长链接）
                        //接受 信息
                        WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
                        //string[] ceshi = "23";
                        //byte de = new byte[204];
                        #region 消息处理 （字符截取 消息转发）
                        try
                        {
                            #region 关闭 socket处理 删除链接池
                            if (socket.State != WebSocketState.Open)
                            {
                                if (ConNect_Pool.ContainsKey(user))
                                    ConNect_Pool.Remove(user);  //删除链接池
                                break;
                            }
                            #endregion
                            //服务端B的连接对象监听到来自A的消息   获取客户端发送的信息
                            string userName = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                            //Encoding.UTF8.GetBytes();
                            string[] msgList = userName.Split('|');
                            if (msgList.Length == 2)
                            {
                                if (msgList[0].Trim().Length > 0)
                                {
                                    descUser = msgList[0].Trim(); //记录消息目的用户
                                }
                                buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msgList[1]));
                            }
                            else
                            {
                                buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userName));
                            }
                            //StreamReader name = new StreamReader(stream,);
                            if (ConNect_Pool.ContainsKey(descUser)) //判断客户户是否存在
                            {
                                WebSocket webSocket = ConNect_Pool[descUser];  //目的客户端
                                if (webSocket != null && webSocket.State == WebSocketState.Open)
                                {
                                    await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                                }
                            }
                            else
                            {
                                await Task.Run(() => 
                                {
                                    if (!Message_Pool.ContainsKey(descUser))  //将用户添加至离线消息池中
                                    {
                                        Message_Pool.Add(descUser, new List<MessageInfo>());
                                    } 
                                    Message_Pool[descUser].Add(new MessageInfo(DateTime.Now, buffer)); //添加离线消息
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            var cc = ex.Message;
                            throw;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    //public struct Stru
    //{
    //    public int a;

    //    public Stru(int a)
    //    {
    //        this.a = a;
    //    }

    //    public void Name(string[] name)
    //    {

    //    }

    //    public
    //}
    //public struct Stru
    //{
    //    public int a;

    //    public Stru(int a)
    //    {
    //        this.a = a;
    //    }

    //    public void Name(string[] name)
    //    {

    //    }

    //    public
    //}
}