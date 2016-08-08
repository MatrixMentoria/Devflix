using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoFinalWeb.Startup))]
namespace ProjetoFinalWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
