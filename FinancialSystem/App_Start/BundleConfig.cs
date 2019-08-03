using System.Web;
using System.Web.Optimization;

namespace FinancialSystem
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

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/js/alertify.js",
                      "~/Scripts/js/alertify.min.js",
                      "~/Scripts/js/category.js",
                      "~/Scripts/js/sb-admin-2.js",
                      "~/Scripts/js/sb-admin-2.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            

            bundles.Add(new StyleBundle("~/Content/customCss").Include(
                      "~/Content/css/alertify.bootstrap.css",
                      "~/Content/css/alertify.core.css",
                      "~/Content/css/alertify.default.css",
                      "~/Content/css/sb-admin-2.css",
                      "~/Content/css/sb-admin-2.min.css"));
        }
    }
}
