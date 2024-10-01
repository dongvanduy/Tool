using System.Web.Optimization;

namespace RE_Tool
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.js"));

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
                  "~/Content/assets/css/bootstrap-grid.css",
                  "~/Content/assets/css/bootstrap-reboot.css",
                  "~/Content/assets/vendor/bootstrap/css/bootstrap.min.css",
                  "~/Content/assets/vendor/boxicons/css/boxicons.min.css",
                  "~/Content/assets/css/style.css"));
            // Bundles for JS
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/assets/js/main.js"));

            // Enable bundling optimizations
            BundleTable.EnableOptimizations = true;

        }
    }
}
