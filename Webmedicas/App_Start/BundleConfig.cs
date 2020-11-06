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
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/dataTables/dataTablesStyles").Include(
                     //"~/Content/plugins/dataTables/dataTables.bootstrap.css",
                     //"~/Content/plugins/dataTables/dataTables.responsive.css",
                     //"~/Content/plugins/dataTables/dataTables.tableTools.min.css",
                     "~/Content/dataTables/datatables.min.css"));
            // dataTables 
            bundles.Add(new ScriptBundle("~/dataTables").Include(
                       //"~/Scripts/plugins/dataTables/jquery.dataTables.js",
                       //"~/Scripts/plugins/dataTables/dataTables.bootstrap.js",
                       //"~/Scripts/plugins/dataTables/dataTables.responsive.js",
                       //"~/Scripts/plugins/dataTables/dataTables.tableTools.min.js",
                       "~/Scripts/dataTables/datatables.min.js"));
        }
    }
}
