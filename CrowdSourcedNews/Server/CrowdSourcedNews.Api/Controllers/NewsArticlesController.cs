namespace CrowdSourcedNews.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CrowdSourcedNews.Api.Models.NewsArticle;
    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Models;

    public class NewsArticlesController : ApiController
    {
        private readonly INewsArticlesService newsArticles;

        public NewsArticlesController(INewsArticlesService newsArticles)
        {
            this.newsArticles = newsArticles;
        }

        public IHttpActionResult Get()
        {
            var result = this.newsArticles
                .All()
                .OrderByDescending(ar => ar.CreatedOn)
                .ProjectTo<NewsArticleResponseModel>()
               .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(string category)
        {
            var result = this.newsArticles
                .All()
                .Where(a => a.Category.ToLower() == category.ToLower())
                .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.newsArticles.All()
                .Where(ar => ar.Id == id)
                .ProjectTo<NewsArticleResponseModel>()
                .FirstOrDefault();

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

            var dataModel = Mapper.Map<NewsArticle>(model);

            var newArticleId = this.newsArticles.Add(dataModel, this.User.Identity.Name);

            return this.Ok(newArticleId);
        }
    }
}