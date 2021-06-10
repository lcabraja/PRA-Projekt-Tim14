﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Quizkey.Models
{
    public class SQLInsertException : Exception
    {
        public SQLInsertException()
        {
        }

        public SQLInsertException(string message) : base(message)
        {
        }

        public SQLInsertException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SQLInsertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}