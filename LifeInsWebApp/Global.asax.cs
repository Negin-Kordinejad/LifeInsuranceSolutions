using LifeInsWebApp.Helper;
using LifeInsWebApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace LifeInsWebApp
{
    public class Global : HttpApplication
    {
        private ILogger _logger=DataAccessFactory.Log();
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
              new ScriptResourceDefinition
              {
                  Path = "~/scripts/jquery-1.4.1.min.js",
                  DebugPath = "~/scripts/jquery-1.4.1.js",
                  CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js",
                  CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js"
              });
        }
        protected void Session_Start(object sender, EventArgs e)
        {
           DataMangerClassLibrary.Helper.AccessHelper.Initialize(ConfigurationManager
               .ConnectionStrings["NewCnnStr"].ConnectionString);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception _error = Server.GetLastError();
            Server.ClearError();
            _logger.LogException(_error, "0", "Unhandled Error");
            Response.Redirect("");
        }
    }
}