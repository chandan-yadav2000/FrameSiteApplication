using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FrameSiteApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                var con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["dbConnectionStrings"].ConnectionString);
                if (con != null)
                {
                    Response.Write(@"<script language='javascript'>alert('Message: \n" + "Hi!" + " .');</script>");
                }
            }
            catch (Exception)
            {
                // redirect client browser .html friendly error page 
            }
        }

        protected void ApplicationBegin_Requested()
        {

        }
    }
}
