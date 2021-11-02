using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KetoRecipeApp.WebMVC.Startup))]
namespace KetoRecipeApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
