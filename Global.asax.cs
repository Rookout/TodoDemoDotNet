using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Rook;

namespace TodoDemoDotNet
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                System.IO.Directory.CreateDirectory(@"C:\\temp");

            }
            catch { }
            Console.SetOut(new System.IO.StreamWriter(@"C:\\temp\\ConsoleOutput.txt"));
            Thread pingThread = new Thread(() =>
            {
                while (true)
                {
                    Console.Out.Flush();
                    Thread.Sleep(1000);
                }
            });
            pingThread.Start();

            try
            {
                Rook.RookOptions o = new RookOptions();
                o.token = "TOKEN";
                o.debug = true;
                Rook.API.Start(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
