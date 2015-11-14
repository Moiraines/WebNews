namespace CrowdSourcedNews.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using CrowdSourcedNews.Api.Models.NewsArticle;
    using CrowdSourcedNews.Data.Services.Contracts;

    public class NewsArticlesController : ApiController
    {
        private readonly INewsArticlesService newsArticles;

        public NewsArticlesController(INewsArticlesService newsArticles)
        {
            this.newsArticles = newsArticles;
        }

        public IHttpActionResult Get()
        {
            var result = this.newsArticles.All().ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.newsArticles.All().FirstOrDefault(ar => ar.Id == id);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(NewsArticleRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newArticleId = this.newsArticles.Add(model.Name, model.Content, this.User.Identity.Name);

            return this.Ok(newArticleId);
        }
    }
}