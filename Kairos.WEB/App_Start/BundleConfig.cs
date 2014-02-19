using System.Web;
using System.Web.Optimization;

namespace Kairos.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Core Libraries

            bundles.Add(new ScriptBundle("~/Scripts/lib/jquery").Include(
            "~/Scripts/lib/jquery-{version}.js"));

            //TIP: Always add Angular.js reference first before adding other angular libraries.
            bundles.Add(new ScriptBundle("~/Scripts/lib/angular").Include(
            "~/Scripts/lib/angular.js",
            "~/Scripts/lib/angular-*"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Scripts/lib/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));

            #endregion


            #region External Libraries
            //ADD External JS Libraries
            bundles.Add(new ScriptBundle("~/Scripts/lib/extlibs").Include(
                "~/Scripts/lib/bootstrap.js"));

            #endregion

            #region App Libraries
            //Add App files
            bundles.Add(new ScriptBundle("~/Scripts/app/applibs").Include(
                "~/Scripts/app/*.js"));
            //Add Controllers
            bundles.Add(new ScriptBundle("~/Scripts/app/controllers").Include(
                "~/Scripts/app/controllers/*.js"));
            //Add Services
            bundles.Add(new ScriptBundle("~/Scripts/app/services").Include(
                "~/Scripts/app/services/*.js"));

            #endregion

            #region CSS
            //ADD CSS to Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/bootstrap-theme.css",
                "~/Content/css/site.css"));
            #endregion
        }
    }
}
