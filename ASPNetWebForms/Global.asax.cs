using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ASPNetWebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["Counter"] = 1;
        }

        void Application_End(object sender, EventArgs e)
        {
            Application["Status"] = "End";
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["Session"] = "Start";
            //int Counter = Convert.ToInt32(Application["Counter"].ToString());
            Application["Counter"] = Convert.ToInt32(Application["Counter"])  +  1;
        }

    }
}