using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TruongAnhTuan.Startup))]
namespace TruongAnhTuan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
