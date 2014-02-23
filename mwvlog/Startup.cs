using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mwvlog.Startup))]
namespace mwvlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
