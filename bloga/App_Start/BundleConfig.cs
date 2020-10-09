using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace bloga.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
               "~/Scripts/bootstrap.min.js",
               "~/Scripts/jquery-3.0.0.min.js",
               "~/Scripts/main.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/css").Include(
           "~/Content/bootstrap.min.csss",
           "~/Content/main.css"
    ));

        }
    }
}