using System;

namespace LifeInsWebApp.Helper
{
    public interface ILogger
    {
        void LogException(Exception exception, string InsuredOrganCode, string Nationalcode, string errorCode = "");
    }
}