using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(carglass.Startup))]
namespace carglass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
