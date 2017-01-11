using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpletnaDrazba.Startup))]
namespace SpletnaDrazba
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
