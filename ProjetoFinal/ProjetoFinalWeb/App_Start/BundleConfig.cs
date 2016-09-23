using System.Web;
using System.Web.Optimization;

namespace ProjetoFinalWeb
{
    /// <summary>
    /// Classe que faz o Bundling. Otimiza e compacta arquivos CSS(style sheet) e arquivos de script.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Método que contém uma série de declarações, com objetivo de registrar bibliotecas e folhas de estilo CSS.
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery.blueimp-gallery.min.js",
                      "~/Scripts/touchSwipe.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/script.js",
                      "~/Scripts/masonry.pkgd.js",
                      "~/Scripts/mansory.pkgd.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/themes/base/jquery-ui.min.css",
                     "~/Content/font-awesome.min.css",
                     "~/Content/bootstrap.css",
                      "~/Content/animate.css",
                      "~/Content/blueimp-gallery.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/set.css",
                      "~/Content/style.css",
                      "~/Content/Site.css"));

            }
        }
    }
