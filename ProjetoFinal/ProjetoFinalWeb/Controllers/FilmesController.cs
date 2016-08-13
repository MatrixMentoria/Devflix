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
            string json = null;

            //API que retorna a collection de filmes
            string url = "http://www.omdbapi.com/?s=" + nome + "&type=movie";

            // ------  API que retorna 1 filme apenas
            // ------  string url = "http://www.omdbapi.com/?t=" + nome + "&y=&plot=short&r=json";


            //if (url != "")
            //{
            try
            {
                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(url);
                }

                //Editando o JSON retornado com Substring
                string jsonEditado = json.Substring(10, json.Length - 10);
                var indexoff = jsonEditado.IndexOf("]");
                jsonEditado = jsonEditado.Substring(0, indexoff + 1);
                json = jsonEditado;


                itens = JsonConvert.DeserializeObject<List<FilmesModel>>(json);    
                
          if(itens.Any(lambda => String.IsNullOrEmpty(lambda.Poster)))
                {
                    ViewBag.paraoErro = 1;
                    return View();
                }
            }
            catch(WebException)
            {
                ViewBag.Erro = "Conexão Indisponivel";
            }

            //}
            //else
            //{
            //    itens = new List<FilmesModel>();
            //}

            return View(itens);
        }
    }
}
