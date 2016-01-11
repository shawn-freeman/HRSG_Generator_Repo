using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRSG_HandbookGenerator.Startup))]
namespace HRSG_HandbookGenerator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
