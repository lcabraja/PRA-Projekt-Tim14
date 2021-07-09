using Quizkey.Models;
using System;
//using

namespace Quizkey
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            //RouteTable.Routes.MapHubs();
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            if (EndOfQuiz.TransmittingFile)
            {
                EndOfQuiz.TransmittingFile = false;
                return;
            }
            //Response.Write("<script src=\"Scripts/bootstrap.js\"></script>" +
            //    "<script src=\"Scripts/jquery-3.6.0.js\"></script>" +
            //    "<script>$(\"document\").ready(function () { " +
            //    "$('head').append(\"" +
            //    "<link href =\\\"Content/bootstrap.css\\\" rel=\\\"stylesheet\\\" />" +
            //    "<link rel =  \\\"stylesheet\\\"href = \\\"https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css\\\">" +
            //    "<meta charset=\\\"utf-8\\\"><meta name=\\\"viewport\\\" content=\\\"width=device-width, initial-scale=1\\\">" +
            //    "\");});</script>");
        }
    }
}
/*

 */