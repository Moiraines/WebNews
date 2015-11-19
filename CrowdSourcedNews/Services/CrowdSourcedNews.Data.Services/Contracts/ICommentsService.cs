using CrowdSourcedNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcedNews.Data.Services.Contracts
{
    public interface ICommentsService
    {
        IQueryable<Comment> All();

        int Add(int newsArticleId, Comment model, string username);

        int AddSubComment(int commentId, Comment model, string username);

        int SaveChanges();
    }
}
