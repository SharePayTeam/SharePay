using System.Web;
using System.Web.Optimization;

namespace SharePay.Web
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

            bundles.Add(new ScriptBundle("~/bundles/base").Include(
                        "~/Scripts/Custom/base-functionality.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                        "~/assets/js/core/popper.min.js",
                        "~/assets/js/bootstrap-material-design.js",
                        "~/assets/js/plugins/perfect-scrollbar.jquery.min.js",
                        "~/assets/js/plugins/moment.min.js",
                        "~/assets/js/plugins/bootstrap-datetimepicker.min.js",
                        "~/assets/js/plugins/nouislider.min.js",
                        "~/assets/js/plugins/bootstrap-selectpicker.js",
                        "~/assets/js/plugins/bootstrap-tagsinput.js",
                        "~/assets/js/plugins/jasny-bootstrap.min.js",
                        "~/assets/assets-for-demo/js/modernizr.js",
                        "~/assets/assets-for-demo/js/vertical-nav.js",
                        "~/assets/js/material-dashboard.js",
                        "~/assets/js/plugins/arrive.min.js",
                        //"~/assets/js/plugins/jquery.validate.min.js",
                        "~/assets/js/plugins/chartist.min.js",
                        "~/assets/js/plugins/jquery.bootstrap-wizard.js",
                        "~/assets/js/plugins/bootstrap-notify.js",
                        "~/assets/js/plugins/jquery-jvectormap.js",
                        "~/assets/js/plugins/nouislider.min.js",
                        "~/assets/js/plugins/jquery.select-bootstrap.js",
                        "~/assets/js/plugins/jquery.datatables.js",
                        "~/assets/js/plugins/sweetalert2.js",
                        "~/assets/js/plugins/fullcalendar.min.js",
                        "~/assets/js/plugins/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/assets/css/material-dashboard.css",
                "~/Content/site.css"));
        }
    }
}
