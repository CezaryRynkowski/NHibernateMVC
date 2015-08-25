using System.Collections.Generic;
using System.IO;
using System.Web.Optimization;

namespace NHibernateMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var scriptsBundle = new ScriptBundle("~/js/scripts/all");
            scriptsBundle.Orderer = new AsIsBundleOrderer();
            scriptsBundle
                .Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/jquery-ui-{version}.js",
                    "~/Scripts/globalize.js",
                    "~/Scripts/globalize.culture.en-GB.js",
                    "~/Scripts/globalize.culture.pl-PL.js",
                    "~/Scripts/jquery.selectboxes.js",
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/jquery.validate.unobtrusive.js",
                    "~/Scripts/jquery.cookie.js",
                    "~/Scripts/jquery-ui-i18n.js");
                        //.IncludeDirectory("~/Scripts/Localization", "*.js", searchSubdirectories: false)
                        //.IncludeDirectory("~/Scripts/Application", "*.js", searchSubdirectories: false);

            bundles.Add(scriptsBundle);

            var cssBundle = new StyleBundle("~/css");
            cssBundle.Orderer = new AsIsBundleOrderer();
            cssBundle.Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/themes/bootstrap-ui/jquery-ui-1.10.0.custom.css",
                "~/Content/styles.css");
            bundles.Add(cssBundle);

            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.min.js");
            bundles.IgnoreList.Ignore("*.min.css");
        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public virtual IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}