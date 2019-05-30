using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookshelfMVC.Startup))]
namespace BookshelfMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
