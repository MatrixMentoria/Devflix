using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjetoFinalWeb.Models
{
    /// <summary>
    /// Classe de usuário, está herdando as propriedades da classe IdentityUser.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    /// <summary>
    /// Classe de contexto, interação de dados com objetos. 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<PlaylistModel> Playlists { get; set; }
        public DbSet<PlayListFilmesModel> PlaylistsFilmes{ get; set; }
        public DbSet<FilmesModel> Filmes{ get; set; }

        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }
    }


}