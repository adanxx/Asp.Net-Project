using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Studio_Line.Startup))]
namespace Studio_Line
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
