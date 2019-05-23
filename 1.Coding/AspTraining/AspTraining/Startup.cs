using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspTraining.Startup))]
namespace AspTraining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
