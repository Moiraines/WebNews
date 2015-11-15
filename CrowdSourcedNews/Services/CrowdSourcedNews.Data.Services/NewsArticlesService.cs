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

        public int Add(string name, string content, string author)
        {
            var currentUser = this.users.All().FirstOrDefault(u => u.UserName == author);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var newArticle = new NewsArticle
                                 {
                                     Name = name,
                                     Content = content,
                                     CreatedOn = DateTime.Now,
                                     Author = currentUser
                                 };


            this.newsArticles.Add(newArticle);
            this.newsArticles.SaveChanges();

            return newArticle.Id;
        }
    }
}