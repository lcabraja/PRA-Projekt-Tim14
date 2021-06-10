using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //--------------------------------------------------------Attendee--------------------------------------------------------
    public class Attendee
    {
        public int IDAttendee { get; set; }
        public string Username { get; set; }
        public int SessionID { get; set; }
    }
}
