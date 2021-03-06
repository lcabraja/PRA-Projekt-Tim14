using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //---------------------------------------------------------Author---------------------------------------------------------
    public class Author
    {
        public int IDAuthor { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public override string ToString() =>
                $"IDAuthor: {IDAuthor}, Username: {Username}, PasswordHash: {PasswordHash}, Email: {Email}";

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

            return IDAuthor.Equals((obj as Author).IDAuthor);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDAuthor.GetHashCode();
        }
    }
}
