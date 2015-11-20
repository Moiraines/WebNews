using Microsoft.Owin;

[assembly: OwinStartup(typeof(CrowdSourcedNews.Api.Startup))]

namespace CrowdSourcedNews.Api
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
