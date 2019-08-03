using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinancialSystem.Startup))]
namespace FinancialSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
