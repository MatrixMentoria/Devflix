using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinalWeb.Models;

namespace ProjetoFinalWeb.Controllers
{
    public class FilmesController : Controller
    {
        //public static List<FilmesModel> itens = new List<FilmesModel>();
        public static List<FilmesModel> itens;

        // GET: Teste
        public ActionResult Index()
        {
            /*string json = null;
            string url2 = "http://www.omdbapi.com/?t=asdagaasfd&y=&plot=short&r=json";
            if (url2 != "")
            {
                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(url2);
                }
                var arquivoJson = JsonConvert.DeserializeObject<FilmesModel>(json);
                itens = new List<FilmesModel>() { arquivoJson };
            }
            else
            {
                itens = new List<FilmesModel>();
            }*/
            itens = new List<FilmesModel>();
            return View(itens);
        }

        [HttpPost]
        public ActionResult Index(string nome)
        {
            if (nome == "")
            {
                RedirectToAction("Index");
            }
            string json = null;
            string url = "http://www.omdbapi.com/?t=" + nome + "&y=&plot=short&r=json";
            if (url != "")
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        json = wc.DownloadString(url);
                    }
                    var arquivoJson = JsonConvert.DeserializeObject<FilmesModel>(json);
                    if (arquivoJson.Response == "False")
                    {
                        ViewBag.Erro = "Impossivel encontrar o filme";
                    }
                    else
                    {
                        itens = new List<FilmesModel>() { arquivoJson };
                    }
                }
                catch (WebException)
                {
                    ViewBag.Erro = "Conexão Ruim com o Servidor...";
                }

//                itens.Add(arquivoJson);
            }
            else
            {
                itens = new List<FilmesModel>();
            }
            return View(itens);
        }
    }
}