namespace LifeInsWebApp.Helper
{
    public interface IMailSender
    {
        void SendForgetEmail(string ToEmailAddress, string Username);
        void SendExceptionEmail(string EmailBody, string ToEmailAddress);
    }
}