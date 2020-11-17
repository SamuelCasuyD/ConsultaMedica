using System.Web;
using System.Web.Optimization;

namespace Webmedicas
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.5.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bootstrap").Include(
                 //"~/Scripts/bootstrap.min.js",
                 //"~/Scripts/bootstrap.bundle.js",                
                 "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            //dataTables CSS styles
            bundles.Add(new StyleBundle("~/Content/dataTables").Include(
                //"~/Content/dataTables/dataTables.bootstrap.css",
                "~/Content/dataTables/datatables.min.css"
                //"~/Content/dataTables/dataTables.responsive.css",
                /*"~/Content/dataTables/dataTables.tableTools.min.css"*/));

            //dataTable
            bundles.Add(new ScriptBundle("~/Scripts/dataTables").Include(                       
                       //"~/Scripts/dataTables/dataTables.bootstrap.js",
                       //"~/Scripts/dataTables/dataTables.responsive.js",
                       //"~/Scripts/dataTables/dataTables.tableTools.min.js",                       
                       //"~/Scripts/dataTables/jquery.dataTables.js"
                       "~/Scripts/dataTables/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/Popper").Include(
                    "~/Scripts/umd/popper.min.js"));

            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/sweetalert/sweetAlertStyles").Include(
                      "~/Content/plugins/sweetalert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/plugins/sweetAlert").Include(
                      "~/Scripts/plugins/sweetalert/sweetalert.min.js"));

        }
    }
}
