using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Todo01._01vercion.Startup))]
namespace Todo01._01vercion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
