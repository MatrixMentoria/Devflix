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
using Microsoft.AspNet.Identity.Owin;

namespace ProjetoFinalWeb.Controllers
{

    public class FilmesController : Controller
    {
        public ActionResult Index()
        {
            return View(Enumerable.Empty<FilmesModel>());
        }

        [HttpPost]
        public async Task<PartialViewResult> BuscarItens(string nome)
        {
            OMDService service = new OMDService();

            var filmes = await service.ObterFilmesPorNome(nome);
            var capaService = new BaixarCapaFilmeService();

            foreach (var filme in filmes)
            {
                await capaService.PegarCapa(filme);
            }

            if (filmes.Count == 0)
            {
                ViewBag.Erro2 = "SIM";
                ViewBag.Erro = string.Format("O Filme {0} não foi encontrado!", nome);
            }
            return PartialView("_ListarFilmes", filmes);
        }

        public async Task<ActionResult> Buscar(string term)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmesPorNome(term);

            if (result.Count == 0)
            {
                ViewBag.Erro2 = "SIM";
                ViewBag.Erro = string.Format("O Filme {0} não foi encontrado!", term);
            }
            return Json(result.Select(x => new { value = x.Title, label = x.Title }), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<PartialViewResult> BuscarItem(string nome)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Usuario = user.Id;

            OMDService service = new OMDService();

            var result = await service.ObterFilmePorNomeComDetalhe(nome);

            return PartialView("_Detalhes", result);
        }


        [HttpPost]
        public async Task<PartialViewResult> TodosDetalhes(string nome)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmePorNomeComDetalhe(nome);

            return PartialView("TodosDetalhes", result);
        }
        
        private ApplicationDbContext contexto = new ApplicationDbContext();

        [HttpPost]
        public async Task<ActionResult> AdicionarNaPlaylist(string nome, Guid PlaysID, string imdbID)
        {
            var service = new OMDService();

            //Obtém o User ID.
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var filme = contexto.Filmes.FirstOrDefault(x => x.imdbID == imdbID);

            if (filme == null)
            {
                //Obtém o Filme.
                filme = await service.ObterFilmePorNomeComDetalhe(nome);
                contexto.Filmes.Add(filme);
                await contexto.SaveChangesAsync();
            }

            //Verificação se o filme já está contido na mesma playlist

            var existsOnPlaylist = contexto.PlaylistsFilmes
                .Any(x => x.PlayListID == PlaysID &&
                    x.FilmesId == x.FilmesId &&
                    x.UsuarioID == user.Id);

            if (!existsOnPlaylist)
            {
                //Rotina Principal
                var playlist = new PlayListFilmesModel
                {
                    DataInclusao = DateTime.Now,
                    FilmeTitulo = nome,
                    UsuarioID = user.Id,
                    PlayListID = PlaysID,
                    FilmesId = filme.FilmesId
                };
                contexto.PlaylistsFilmes.Add(playlist);
                await contexto.SaveChangesAsync();
            }
            else
            {
                ViewBag.FilmeJaEstaContido = "Filme Já está na Playlist";
            }

            return RedirectToAction("BuscarItem");
        }
    }


    //O modo antigo, só com uma playlist

    /*public async Task<ActionResult> AdicionarNaPlaylist(string TituloFilme)
    {
        FilmesModel filmes = new FilmesModel();
        ApplicationUser usuario = new ApplicationUser();
        PlaylistModel playlist = new PlaylistModel();

        using (var context = new ApplicationDbContext())
        {
            if (!context.PlaylistsFilmes.Any(lambda => TituloFilme == lambda.FilmeTitulo))
            {
                PlayListFilmesModel play = new PlayListFilmesModel
                {
                    DataInclusao = DateTime.Now,
                    FilmeTitulo = TituloFilme,
                    FilmeID = filmes.Id,
                    UsuarioID = usuario.Id,
                    PlayListID = playlist.PlaylistId
                };

                context.PlaylistsFilmes.Add(play);
                await context.SaveChangesAsync();
            }
            return View();
        }
    }*/
}

