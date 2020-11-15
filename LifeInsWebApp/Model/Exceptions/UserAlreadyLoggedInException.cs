using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeInsWebApp.Model.Exceptions
{
    public class UserAlreadyLoggedInException : Exception
    {
        public UserAlreadyLoggedInException()
            : base()
        {
        }
        public UserAlreadyLoggedInException(string Message)
           : base(Message)
        {
        }
        public UserAlreadyLoggedInException(string Message,Exception InnerException)
          : base(Message,InnerException)
        {
        }
    }
}