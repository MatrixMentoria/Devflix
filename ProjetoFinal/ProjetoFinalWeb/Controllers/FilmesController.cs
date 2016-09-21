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

    /// <summary>
    /// Controller dos filmes buscados no sistema.
    /// </summary>
    public class FilmesController : Controller
    {
        /// <summary>
        /// Action que enumera os filmes buscados na lista FilmesModel.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(Enumerable.Empty<FilmesModel>());
        }

        /// <summary>
        /// Método que envia uma exibição parcial do resultado da busca.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
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
                ViewBag.Erro = string.Format("Filme {0} não encontrado", nome);
              return PartialView("ErroFilmeNaoEncontrado");
            }

            return PartialView("_ListarFilmes", filmes);
        }

        /// <summary>
        /// Método que busca o filme e retorna um arquivo Json
        /// ou retorna uma mensagem de erro caso o filme não seja encontrado.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public async Task<ActionResult> Buscar(string term)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmesPorNome(term);

            if (result.Count == 0)
            {
                ViewBag.Erro = string.Format("Filme {0} não encontrado", term);
                return PartialView("ErroFilmeNaoEncontrado");
            }

            return Json(result.Select(x => new { value = x.Title, label = x.Title }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Método que retorna uma exibição partial do filme com a Pop-up Detalhes.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que retorna uma exibição partial do filme com todos os detalhes.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PartialViewResult> TodosDetalhes(string nome)
        {
            OMDService service = new OMDService();

            var result = await service.ObterFilmePorNomeComDetalhe(nome);

            return PartialView("TodosDetalhes", result);
        }
        
        private ApplicationDbContext contexto = new ApplicationDbContext();

        /// <summary>
        /// Método para adicionar os filmes buscados na Playlist.
        /// </summary>
        /// <param name="filmeNome"></param>
        /// <param name="PlaysID"></param>
        /// <param name="imdbID"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AdicionarNaPlaylist(string filmeNome, Guid PlaysID, string imdbID)
        {
            var service = new OMDService();

            //Obtém o User ID.
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var filme = contexto.Filmes.FirstOrDefault(x => x.imdbID == imdbID);

            if (filme == null)
            {
                //Obtém o Filme.
                filme = await service.ObterFilmePorNomeComDetalhe(filmeNome);
                contexto.Filmes.Add(filme);
                await contexto.SaveChangesAsync();
            }

            //Verificação se o filme já está contido na mesma playlist

            var existsOnPlaylist = contexto.PlaylistsFilmes
                .Any(x => x.PlayListID == PlaysID &&
                    x.FilmesId == filme.FilmesId &&
                    x.UsuarioID == user.Id);

            if (!existsOnPlaylist)
            {
                //Rotina Principal
                var playlist = new PlayListFilmesModel
                {
                    DataInclusao = DateTime.Now,
                    FilmeTitulo = filmeNome,
                    UsuarioID = user.Id,
                    PlayListID = PlaysID,
                    FilmesId = filme.FilmesId
                };
                contexto.PlaylistsFilmes.Add(playlist);
                await contexto.SaveChangesAsync();
                return Json(new
                {
                    Success = true,
                    Message = string.Format("O filme {0} foi adicionado a playlist com sucesso.", filmeNome)

                });
            }
            else
            {
                return Json(new
                {
                    Success = false,
                    Message = string.Format("O filme {0} ja foi adicionado a playlist.", filmeNome)

                });
            }
        }

        /// <summary>
        /// Método para exibir os filmes contidos na Playlist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ExibirFilmesPlaylist(Guid id)
        {
            // Recuperando Id do usuário logado
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
     
            var filmesPlaylistViewModel = new List<FilmesPlaylistViewModel>();

            // 
            var result = contexto.PlaylistsFilmes.Where(x => x.UsuarioID == user.Id.ToString() && x.PlayListID == id);
            foreach (var item in result)
            {  
                var filme = contexto.Filmes.FirstOrDefault(x => x.FilmesId == item.FilmesId);
                filmesPlaylistViewModel.Add(new FilmesPlaylistViewModel
                {
                    ImdbId = filme.imdbID,
                    PlayListID = item.PlayListID,
                    FilmesId = item.FilmesId,
                    UsuarioID = item.UsuarioID,
                    FilmeTitulo = filme.Title,
                    DataInclusao = item.DataInclusao,
                });
            }

            return PartialView(filmesPlaylistViewModel);
        }

        public async Task<ActionResult> CarregarDropUpPlaylists()
        {   
            var usuario = contexto.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
            string DEFAULT_PLAYLIST = "Ver depois";

            // #Ver depois pro mentor não reclamar <3 LINQ
            var usuarioPlaylists = contexto.Playlists
                .Where(x => x.UsuarioId == usuario.Id || x.Titulo == DEFAULT_PLAYLIST)
                .ToList();

            return PartialView("DropUpPlaylistsView", usuarioPlaylists);
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

