using System.Web;

namespace Quizkey.Cookies
{
    public class CookieParseWrapper
    {
        public HttpCookie RequestCookie { get; private set; }

        public CookieParseWrapper(HttpCookie requestCookie) => 
            RequestCookie = requestCookie;
    }
}