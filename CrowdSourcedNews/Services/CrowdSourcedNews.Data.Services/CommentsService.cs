namespace CrowdSourcedNews.Data.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        private readonly IRepository<NewsArticle> newsArticles;

        private readonly IRepository<User> users;

        public CommentsService(IRepository<NewsArticle> newsArticleRepository, IRepository<Comment> commentsRepository, IRepository<User> usersRepository)
        {
            this.newsArticles = newsArticleRepository;
            this.comments = commentsRepository;
            this.users = usersRepository;
        }

        public int Add(int newsArticleId, Comment model, string username)
        {
            var currentUserId = this.users.All()
                .Where(u => u.UserName == username)
                .Select(u => u.Id)
                .First();
            
            model.AuthorId = currentUserId;

            var article = this.newsArticles.GetById(newsArticleId);

            if (article == null)
            {
                throw new ArgumentException("News article cannot be found!");
            }

            this.comments.Add(model);
            article.Comments.Add(model);

            this.SaveChanges();

            return model.Id;
        }

        public int AddSubComment(int commentId, Comment model, string username)
        {
            var currentUserId = this.users.All()
               .Where(u => u.UserName == username)
               .Select(u => u.Id)
               .First();

            model.AuthorId = currentUserId;

            var comment = this.comments.GetById(commentId);

            if (comment == null)
            {
                throw new ArgumentException("Comment cannot be found!");
            }

            comment.SubComments.Add(model);

            this.SaveChanges();

            return model.Id;
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public int SaveChanges()
        {
            return this.comments.SaveChanges();
        }
    }
}
