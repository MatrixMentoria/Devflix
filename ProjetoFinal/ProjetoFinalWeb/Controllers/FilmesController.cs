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
using ProjetoFinalWeb.Services;
namespace ProjetoFinalWeb.Controllers
{

    public class FilmesController : Controller
    {

        public ActionResult Index()
        {
            return View(Enumerable.Empty<FilmesModel>());
        }

        [HttpPost]
        public async Task<PartialViewResult> Index(string nome)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmesPorNome(nome);

            if (result.Count == 0) {
                ViewBag.Erro = string.Format("O Filme {0} não foi encontrado!", nome);
            }
            return PartialView("_ListarFilmes", result);
        }
        
        public async Task<ActionResult> Buscar(string term)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmesPorNome(term);

            if (result.Count == 0)
            {
                ViewBag.Erro = string.Format("O Filme {0} não foi encontrado!", term);
            }
            return Json(result.Select(x => new { value = x.Title, label = x.Title }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<PartialViewResult> BuscarItem(string nome)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmePorNomeComDetalhe(nome);
            
            return PartialView("_Detalhes", result);
        }
    }
}
