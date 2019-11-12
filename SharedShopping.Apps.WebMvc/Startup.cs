using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SharedShopping.Apps.WebMvc.Startup))]
namespace SharedShopping.Apps.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            configureAuth(app);
            configureDependencies(app);
        }
    }
}
