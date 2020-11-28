using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace LifeInsWebApp.Helper
{
    public class MailSender : IMailSender
    {
        public void SendForgetEmail(string ToEmailAddress, string Username)
        {
            String myGUID = Guid.NewGuid().ToString();
            string EmailBody = "Hi " + Username + ",<br/><br/> Click the link below to reset your " +
                "password <br/><br/> http://localhost:48599/RecoverPassword.aspx?Uid=" + myGUID;
            MailMessage PassRecMail = new MailMessage("youremail@gmail.com", ToEmailAddress);
            PassRecMail.Body = EmailBody;
            PassRecMail.IsBodyHtml = true;
            PassRecMail.Subject = "Reset Password";
            Send(PassRecMail);

        }

        public void SendExceptionEmail(string EmailBody, string ToEmailAddress)
        {
            MailMessage ExcMail = new MailMessage("n@gmail.com", ToEmailAddress);
            ExcMail.Body = EmailBody;
            ExcMail.Subject = "Exception";
            Send(ExcMail);

        }
        private void Send(MailMessage Email)
        {
            //SmtpClient SMTP = new SmtpClient("smtp-mail.outlook.com", 587);
            SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
            SMTP.Credentials = new NetworkCredential()
            {
                UserName = "n@gmail.com",
                Password = "password"
            };
            SMTP.EnableSsl = true;
            SMTP.Send(Email);
        }
    }
}