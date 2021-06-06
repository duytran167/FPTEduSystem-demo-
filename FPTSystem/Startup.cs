using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FPTSystem.Startup))]
namespace FPTSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
