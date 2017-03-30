using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarCrawler.Startup))]
namespace BarCrawler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
