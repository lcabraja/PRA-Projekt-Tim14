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
        public override string ToString() =>
                $"IDAttendee: {IDAttendee}, Username: {Username}, SessionID: {SessionID}";


        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return IDAttendee.Equals((obj as Attendee).IDAttendee);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDAttendee.GetHashCode();
        }
    }
}
