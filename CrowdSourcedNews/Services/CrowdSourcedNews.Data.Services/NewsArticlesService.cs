namespace CrowdSourcedNews.Data.Services
{
    using System.Linq;
    using CrowdSourcedNews.Data.Services.Contracts;
    using Models;

    public class NewsArticlesService : INewsArticlesService
    {
        private readonly IRepository<NewsArticle> newsArticles;

        public NewsArticlesService()
        {
            var db = new CrowdSourcedNewsDbContext();

            this.newsArticles = new EfGenericRepository<NewsArticle>(db);
        }

        public IQueryable<NewsArticle> All()
        {
            var result = this.newsArticles
                .All();

            return result;
        }
    }
}
