using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(report_manajemen.Startup))]
namespace report_manajemen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
