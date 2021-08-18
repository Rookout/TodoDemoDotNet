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

            HugeLib.Class0 cl0 = new HugeLib.Class0();
            HugeLib.Class10 cl10 = new HugeLib.Class10();

            HugeLib2.Class0 cl20 = new HugeLib2.Class0();
            HugeLib2.Class10 cl210 = new HugeLib2.Class10();
            
            HugeLib3.Class0 cl2a0 = new HugeLib3.Class0();
            HugeLib3.Class10 cl2a10 = new HugeLib3.Class10();
            
            HugeLib4.Class0 cl230 = new HugeLib4.Class0();
            HugeLib4.Class10 cl2d10 = new HugeLib4.Class10();
            
            HugeLib5.Class0 cl250 = new HugeLib5.Class0();
            HugeLib5.Class10 cl2u10 = new HugeLib5.Class10();
            
            HugeLib6.Class0 cl280 = new HugeLib6.Class0();
            HugeLib6.Class10 cl2k10 = new HugeLib6.Class10();
            
            HugeLib7.Class0 cl270 = new HugeLib7.Class0();
            HugeLib7.Class10 cl2f10 = new HugeLib7.Class10();
            
            HugeLib8.Class0 cl2t0 = new HugeLib8.Class0();
            HugeLib8.Class10 cl2tt10 = new HugeLib8.Class10();
            
            HugeLib9.Class0 cl2yy0 = new HugeLib9.Class0();
            HugeLib9.Class10 cl2888810 = new HugeLib9.Class10();


            Dictionary<string, List<string>> a = new Dictionary<string, List<string>>();
            a.Add("123", new List<string>());
            a.Add("321", new List<string>());
            a.Add("222", new List<string>());
            var x = a.ContainsKey("123");

            //try
            //{
            //    System.IO.Directory.CreateDirectory(@"C:\\temp");
            //
            //}
            //catch { }
            //Console.SetOut(new System.IO.StreamWriter(@"C:\\temp\\ConsoleOutput.txt"));
            //Thread pingThread = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //
            //            Console.Out.Flush();
            //        }
            //        catch
            //        {
            //        }
            //
            //        Thread.Sleep(1000);
            //    }
            //});
            //pingThread.Start();

            try
            {
                Rook.RookOptions o = new RookOptions();
                o.debug = true;
                o.token = "8f841612a078467fbc19ce7a3bd5da511e7b8714ad5b4391a206defa79ade4d8";
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
