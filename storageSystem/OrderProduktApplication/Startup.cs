using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderProduktApplication.Startup))]
namespace OrderProduktApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
