namespace CrowdSourcedNews.Api
{
    using App_Start;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfing.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
