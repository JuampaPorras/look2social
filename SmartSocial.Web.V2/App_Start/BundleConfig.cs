using System.Web.Optimization;

namespace SmartSocial.web.V2
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
          

             //Pages
            bundles.Add(new ScriptBundle("~/bundles/pages").Include(
                        "~/Scripts/Pages/app.js",
                        "~/Scripts/Pages/layout.js",
                        "~/Scripts/Pages/mainReport.js",
                        "~/Scripts/Pages/noReport.js",
                        "~/Scripts/Pages/manage.js"));

            //Plugins
             bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/Plugins/jquery.gritter.js",
                        //"~/Scripts/Plugins/html2canvas.js",
                        "~/Scripts/jquery.dynamic.js",
                        "~/Scripts/Plugins/sweet-alert.js"));
//"~/Scripts/Pages/reportShared.js",


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/site").Include("~/Content/icons.css",
    "~/Content/bootstrap.css",
    "~/Content/bootstrapCustomized.css",
    "~/Content/plugins.css" ,
    "~/Content/main.css" ,
    "~/Content/smartsocialstyle.css" ,
    "~/Content/flags.css"));


            

            BundleTable.EnableOptimizations = false;
        }
    }
}