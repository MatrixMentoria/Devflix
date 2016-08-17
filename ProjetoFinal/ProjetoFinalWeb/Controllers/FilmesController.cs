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
        public async Task<ActionResult> Index(string nome)
        {
            OMDService service = new OMDService();
            return View(await service.ObterFilmesPorNome(nome));
        }
    }
}
