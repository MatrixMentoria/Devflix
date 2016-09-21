using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using ProjetoFinalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinalWeb.Controllers
{
    /// <summary>
    /// Controller da tela inicial.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Método da tela Home do sistema.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {       
            return View();
        }

        /// <summary>
        /// Método da tela ABout do sistema.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Método da tela de contato do sistema.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}