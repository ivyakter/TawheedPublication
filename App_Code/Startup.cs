using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TawheedPublication.Startup))]
namespace TawheedPublication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
