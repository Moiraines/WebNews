namespace CrowdSourcedNews.Data.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface INewsArticlesService
    {
        IQueryable<NewsArticle> All();

        int Add(string name, string content, string author);
    }
}
