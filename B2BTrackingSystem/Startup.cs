using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(B2BTrackingSystem.Startup))]
namespace B2BTrackingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
