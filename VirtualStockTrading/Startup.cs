using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualStockTrading.Startup))]
namespace VirtualStockTrading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
