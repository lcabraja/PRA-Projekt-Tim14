using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Quizkey
{
    public class WebSockets : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public static event Action MoveSessionClients;

        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["chatName"];
            clients.Add(this);
            //clients.Broadcast(name + " has connected");
        }

        public static void AnnounceStart(int sessionid)
        {
            clients.Broadcast($"movesession-{sessionid}");
        }

        public override void OnMessage(string message)
        {
            //clients.Broadcast($"{name} said: {message}");
            if (message != null && message.Split('-')[0] == "results" && int.TryParse(message.Split('-')[1], out int result))
            {
                MoveSessionClients?.Invoke();
            }
        }
        public override void OnClose()
        {
            clients.Remove(this);
        }

        internal static void AnnounceEnd(int sessionid)
        {
            clients.Broadcast($"endsession-{sessionid}");
        }

        internal static void AnnounceClient(int sessionid)
        {
            clients.Broadcast($"newclient-{sessionid}");
        }
    }
}