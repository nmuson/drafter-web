using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrafterCf.Startup))]
namespace DrafterCf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
