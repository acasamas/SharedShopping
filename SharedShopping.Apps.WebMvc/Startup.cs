using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharedShopping.Apps.WebMvc.Startup))]
namespace SharedShopping.Apps.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
