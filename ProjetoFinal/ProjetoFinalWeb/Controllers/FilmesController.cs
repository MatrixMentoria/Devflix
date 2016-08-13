using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinalWeb.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Controllers
{
    /// <summary>
    /// http://img.omdbapi.com/?i=tt2294629&apikey=35652245
    /// Passar a utilizar essa chave a partir de amanhã.
    /// Eu fiz o cadastro no site pra ter uma chave
    /// ------  API que retorna 1 filme apenas
    /// ------  string url = "http://www.omdbapi.com/?t=" + nome + "&y=&plot=short&r=json";
    /// </summary>
    public class FilmesController : Controller
    {
        private List<FilmesModel> itens;
        private readonly string BASE_URI = "http://www.omdbapi.com/?s={0}&type=movie";

        public ActionResult Index()
        {
            itens = new List<FilmesModel>();
            return View(itens);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string nome)
        {
            string url = string.Format(BASE_URI, nome);

            try
            {
                System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
                var json = await http.GetStringAsync(url);
                var result = JObject.Parse(json);
                itens = JsonConvert.DeserializeObject<List<FilmesModel>>(result.GetValue("Search").ToString());

                if (itens.Any(lambda => String.IsNullOrEmpty(lambda.Poster)))
                {
                    ViewBag.paraoErro = 1;
                    return View();
                }
            }
            catch (WebException)
            {
                ViewBag.Erro = "Conexão Indisponivel";
            }

            return View(itens);
        }
    }
}
