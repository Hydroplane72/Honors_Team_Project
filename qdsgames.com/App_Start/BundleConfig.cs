using System.Web;
using System.Web.Optimization;

namespace qdsgames.com
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.UseCdn = true;
            var bootstrapjs = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js";
            var bootstrapcss = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css";
            var jqueryjs = "https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.jss";

            bundles.Add(new StyleBundle("~/bootstrap/3.3.7/css/bootstrap.min.css", bootstrapcss));
            bundles.Add(new StyleBundle("~/ajax/libs/jquery/3.2.1/jquery.min.js", jqueryjs));
            bundles.Add(new StyleBundle("~/bootstrap/3.3.7/js/bootstrap.min.js", bootstrapjs));
        }
    }
}
