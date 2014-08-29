using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpEditor.Startup))]
namespace CSharpEditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
