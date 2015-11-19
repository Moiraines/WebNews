namespace CrowdSourcedNews.Data.Services
{
    using System;
    using System.Linq;

    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Models;

    public class NewsArticlesService : INewsArticlesService
    {
        private readonly IRepository<NewsArticle> newsArticles;

        private readonly IRepository<User> users;

        public NewsArticlesService(IRepository<NewsArticle> newsArticleRepository, IRepository<User> usersRepository)
        {
            this.newsArticles = newsArticleRepository;
            this.users = usersRepository;
        }

        public IQueryable<NewsArticle> All()
        {
            var result = this.newsArticles.All();

            return result;
        }

        public int Add(NewsArticle model, string username)
        {
            var currentUser = this.users.All().FirstOrDefault(u => u.UserName == username);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            model.Author = currentUser;

            this.newsArticles.Add(model);
            this.newsArticles.SaveChanges();

            return model.Id;
        }

        public void PositiveVote(int newsArticleId)
        {
            var article = this.newsArticles.GetById(newsArticleId);

            article.PositiveVotes++;

            this.newsArticles.Update(article);

            this.SaveChanges();
        }

        public void NegativeVote(int newsArticleId)
        {
            var article = this.newsArticles.GetById(newsArticleId);

            article.NegativeVotes++;

            this.newsArticles.Update(article);

            this.SaveChanges();
        }

        public int SaveChanges()
        {
            return this.newsArticles.SaveChanges();
        }
    }
}