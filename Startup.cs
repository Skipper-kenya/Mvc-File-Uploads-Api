using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(file_uploads.Startup))]
namespace file_uploads
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
