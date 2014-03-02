using System;
using System.Web;
using System.Web.Optimization;

namespace FormBuilder
{
    public class BundleConfig
    {
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(new ScriptBundle("~/bundles/jqueryie").Include(
                        "~/assets/js/uncompressed/jquery-1.10.2.js",
                        "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/uncompressed/jquery-2.0.3.js",
                        "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/assets/js/uncompressed/bootstrap.js",
                        "~/assets/js/typeahead-bs2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/excanvas").Include(
                "~/assets/js/uncompressed/excanvas.js"));

            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                "~/assets/js/uncompressed/ace-elements.js",
                "~/assets/js/uncompressed/ace.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/assets/js/uncompressed/jquery-ui-{version}.js",
                        "~/assets/js/uncompressed/jquery.ui.touch-punch.js",
                        "~/assets/js/uncompressed/jquery.slimscroll.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/assets/js/uncompressed/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxlogin").Include(
                "~/app/ajaxlogin.js"));

            bundles.Add(new ScriptBundle("~/bundles/todo").Include(                
                "~/app/formBuilder.main.js", // must be first   
                "~/app/models/question.base.js",
                "~/app/models/question.boolean.js",
                "~/app/models/question.date.js",
                "~/app/models/question.int.js",
                "~/app/models/question.money.js",
                "~/app/models/question.multiSelect.js",
                "~/app/models/question.string.js",
                "~/app/formBuilder.datacontext.js",
                "~/app/ControllerViews/dashBoard.controller.js",
                "~/app/ControllerViews/newForm.controller.js",
                "~/app/ControllerViews/publishedFormDetails.controller.js",
                "~/app/ControllerViews/answeredForm.controller.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/myform").Include(
                "~/app/myform.main.js", // must be first   
                "~/app/models/question.base.js",
                "~/app/models/question.boolean.js",
                "~/app/models/question.date.js",
                "~/app/models/question.int.js",
                "~/app/models/question.money.js",
                "~/app/models/question.multiSelect.js",
                "~/app/models/question.string.js",
                "~/app/myform.datacontext.js",
                "~/app/ControllerViews/publishedForm.controller.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/ie7").Include(
                "~/assets/js/uncompressed/excanvas.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie8").Include(
                "~/assets/js/html5shiv.js",
                "~/assets/js/uncompressed/respond.src.js/"));

            bundles.Add(new ScriptBundle("~/bundles/aceextra").Include(
                "~/assets/js/uncompressed/ace-extra.js"));

            bundles.Add(new StyleBundle("~/assets/bootstrap")
                .Include("~/assets/css/uncompressed/bootstrap.css")
                .Include("~/assets/css/uncompressed/font-awesome.css"));

            bundles.Add(new StyleBundle("~/assets/fa-ie7").Include(
                "~/assets/css/uncompressed/font-awesome-ie7.css"
                ));

            bundles.Add(new StyleBundle("~/assets/ie").Include(
                "~/assets/css/uncompressed/ace-ie.css"));

            bundles.Add(new StyleBundle("~/assets/ace").Include(
                "~/assets/css/ace-fonts.css",
                "~/assets/css/uncompressed/ace.css",
                "~/assets/css/uncompressed/ace-rtl.css",
                "~/assets/css/uncompressed/ace-skins.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}