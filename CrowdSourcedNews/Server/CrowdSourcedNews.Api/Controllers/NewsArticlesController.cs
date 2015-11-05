namespace CrowdSourcedNews.Api.Controllers
{
    using Data.Services;
    using Data.Services.Contracts;
    using System.Linq;
    using System.Web.Http;

    public class NewsArticlesController : ApiController
    {
        private readonly INewsArticlesService newsArticles; 

        public NewsArticlesController(INewsArticlesService newsArticles)
        {
            this.newsArticles = newsArticles;
        }

        public NewsArticlesController()
            :this(new NewsArticlesService())
        {
        }

        public IHttpActionResult Get()
        {
            var result = this.newsArticles
                .All()
                .ToList();

            if(result.Count == 0)
            {
               return this.NotFound();
            }

            return this.Ok(result);
        }
    }
}