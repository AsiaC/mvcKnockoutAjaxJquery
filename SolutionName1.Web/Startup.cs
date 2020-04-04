using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolutionName1.Web.Startup))]
namespace SolutionName1.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
