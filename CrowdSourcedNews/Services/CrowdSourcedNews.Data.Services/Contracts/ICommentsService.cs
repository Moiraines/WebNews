namespace CrowdSourcedNews.Data.Services.Contracts
{
    using System.Linq;

    using CrowdSourcedNews.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> All();

        int Add(int newsArticleId, Comment model, string username);

        int AddSubComment(int commentId, Comment model, string username);

        int SaveChanges();
    }
}