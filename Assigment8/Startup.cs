using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assigment8.Startup))]
namespace Assigment8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
