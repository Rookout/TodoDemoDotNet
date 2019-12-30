using System.Web;
using System.Web.Optimization;

namespace TodoDemoDotNet
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.4.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                     "~/Scripts/vue.js"));

            bundles.Add(new ScriptBundle("~/bundles/todoapp").Include(
                     "~/Scripts/todoapp.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/todostyle.css"));
        }
    }
}
