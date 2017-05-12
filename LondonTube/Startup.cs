using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LondonTube.Startup))]
namespace LondonTube
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
