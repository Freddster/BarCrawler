using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proto.Startup))]
namespace proto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
