using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey
{
    public class WebSockets : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["chatName"];
            clients.Add(this);
            clients.Broadcast(name + " has connected");
        }

        public static void AnnounceStart(int sessionid)
        {
            clients.Broadcast($"movesession-{sessionid}");
        }

        public override void OnMessage(string message)
        {
            clients.Broadcast($"{name} said: {message}");
        }
        public override void OnClose()
        {
            clients.Remove(this);
        }

        internal static void AnnounceEnd(int sessionid)
        {
            clients.Broadcast($"endsession-{sessionid}");
        }
    }
}