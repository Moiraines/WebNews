namespace CrowdSourcedNews.Data.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface INewsArticlesService
    {
        IQueryable<NewsArticle> All();

        int Add(NewsArticle model, string username);

        void PositiveVote(int newsArticleId);

        void NegativeVote(int newsArticleId);

        int SaveChanges();
    }
}