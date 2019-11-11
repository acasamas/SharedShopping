using Microsoft.Owin;
using Owin;
using SharedShopping.Domain.Fakes.Services;
using SharedShopping.Domain.Services;

[assembly: OwinStartup(typeof(SharedShopping.Apps.WebMvc.Startup))]
namespace SharedShopping.Apps.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext<IExpenseService>(() => new FakeExpenseService());
        }
    }
}
