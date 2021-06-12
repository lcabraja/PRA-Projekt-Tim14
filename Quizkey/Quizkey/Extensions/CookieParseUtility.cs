using Quizkey.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey
{
    public static class CookieParseUtility
    {
        public static string Enum(this CookieParseWrapper wrapper, UserState state)
        {
            var cookie = wrapper.RequestCookie;
            return cookie[state.ToString()];
        }
    }
}