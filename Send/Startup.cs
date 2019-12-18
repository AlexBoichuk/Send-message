using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Send.Startup))]
namespace Send
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
