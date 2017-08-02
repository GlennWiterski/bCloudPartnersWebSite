using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace bCloudPartnersWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //added this
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsLocal && !HttpContext.Current.Request.Url.Host.StartsWith("www"))
            {
                var Builder = new UriBuilder(Request.Url);
                Builder.Host = "www." + Request.Url.Host;
                Response.RedirectPermanent(Builder.ToString(), true);
            }
      
            var url = Request.Url.ToString();
            if (Regex.IsMatch(url, @"[A-Z]") && Request.HttpMethod != "POST" && !url.Contains("Bundles"))
            {
                Response.Clear();
                Response.Status = "301 Moved Permanently";
                Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
                Response.AddHeader("Location", url.ToLower());
                Response.End();
            }
        }
    }
}
