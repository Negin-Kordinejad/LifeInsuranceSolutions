using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LifeInsWebApp.Helper
{
    public class TextLogger : ILogger
    {
        private void logText(string text)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath("~/Files/Exceptions.txt")))
            {
                File.AppendAllText(
                    HttpContext.Current.Server.MapPath("~/Files/Exceptions.txt"),
                    Environment.NewLine + DateTime.Now.ToString() + " ==> " + text
                );
            }
            else
            {
                throw new FileNotFoundException("The log file is not present");
            }

        }

        public void LogException(Exception exception, string InsuredOrganCode="", string Nationalcode="", string errorCode = "")
        {
            StringBuilder sbExceptionMassage = new StringBuilder();
            do
            {
                sbExceptionMassage.Append("ExeceptionType:");
                sbExceptionMassage.Append(exception == null ? "" : exception.GetType().Name);
                sbExceptionMassage.Append(Environment.NewLine);
                sbExceptionMassage.Append("ErrorCode:");
                sbExceptionMassage.Append(errorCode);
                sbExceptionMassage.Append(Environment.NewLine);
                sbExceptionMassage.Append("InsuredOrganCode:");
                sbExceptionMassage.Append(InsuredOrganCode);
                sbExceptionMassage.Append(Environment.NewLine);
                sbExceptionMassage.Append("NationalCode:");
                sbExceptionMassage.Append(Nationalcode);
                sbExceptionMassage.Append(Environment.NewLine);
                sbExceptionMassage.Append("Massage:");
                sbExceptionMassage.Append(exception == null ? "" : exception.Message);
                sbExceptionMassage.Append(Environment.NewLine);
                sbExceptionMassage.Append("ExceptionTrace:");
                sbExceptionMassage.Append(exception == null ? "" : exception.StackTrace);
                sbExceptionMassage.Append(Environment.NewLine);
                sbExceptionMassage.Append(Environment.NewLine);

                exception = exception.InnerException;
            }
            while (exception != null);
            logText(sbExceptionMassage.ToString());
        }
    }
}