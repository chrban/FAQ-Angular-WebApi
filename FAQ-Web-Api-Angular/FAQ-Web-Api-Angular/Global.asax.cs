using FAQ_Web_Api_Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FAQ_Web_Api_Angular
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

           //Kjøres 1 gang for å fylle databesen med data
           //PopulateDatabase.Populate();
        }
    }
}
