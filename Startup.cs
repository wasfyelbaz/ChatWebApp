using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatWebApp.Startup))]
namespace ChatWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
