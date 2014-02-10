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



            #region CSS
            //ADD CSS to Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/bootstrap-theme.css",
                "~/Content/css/site.css"));
            #endregion
        }
    }
}
