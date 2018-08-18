using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BakeryInventoryProject.Startup))]
namespace BakeryInventoryProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
