using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey
{
    /// <summary>
    /// Summary description for WebSocketEndpoint
    /// </summary>
    public class WebSocketEndpoint : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new WebSockets());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}