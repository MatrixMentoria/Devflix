using Microsoft.AspNet.Identity.Owin;
using ProjetoFinalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinalWeb.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        public async Task<ActionResult> CarregarAdmin()
        {
            var userAdmin = await UserManager.FindByEmailAsync("admin@admin.com");
            if(userAdmin == null)
            {
                userAdmin = new ApplicationUser();
                userAdmin.Nome = "Admin";
                userAdmin.Email = "admin@admin.com";
                userAdmin.UserName = "admin@admin.com";
                userAdmin.EmailConfirmed = true;
                await UserManager.CreateAsync(userAdmin, "123456@@");

                using(var context = new ApplicationDbContext())
                {
                    var playlist = new PlaylistModel
                    {
                        Titulo = "Ver depois",
                        UsuarioId = userAdmin.Id,
                        Padrao = true,
                        Publica = true,
                        DataCriacao = DateTime.Now
                    };

                    context.Playlists.Add(playlist);
                    await context.SaveChangesAsync();
                    
                }
            }



            return View();
        }
    }
}