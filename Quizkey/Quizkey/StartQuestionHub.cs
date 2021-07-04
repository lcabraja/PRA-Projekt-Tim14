using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey
{

    public class StartQuestionHub : Hub
    {
        public static void StartQuestion()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<StartQuestionHub>();
            context.Clients.All.StartQuestion();
        }
    }
    //public class StartQuestionHub// : Hub
    //{
    //    private readonly static Lazy<StartQuestionHub> _instance = new Lazy<StartQuestionHub>(() => new StartQuestionHub(GlobalHost.ConnectionManager.GetHubContext<StartQuestionHub>().Clients));
    //    private IHubConnectionContext<dynamic> Clients { get; set; }
    //    private StartQuestionHub(IHubConnectionContext<dynamic> clients)
    //    {
    //        Clients = clients;
    //    }

    //    //[HubMethodName("start")]
    //    public static void StartQuestion()
    //    {
    //        //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<StartQuestionHub>();

    //        //context.Clients.All.StartQuestion();
    //        Clients.All.StartQuestion();
    //    }
    //}
}