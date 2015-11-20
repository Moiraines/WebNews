namespace CrowdSourcedNews.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<NewsArticle> newsArticles;

        public Category()
        {
            this.newsArticles = new HashSet<NewsArticle>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<NewsArticle> NewsArticles
        {
            get { return this.newsArticles; }
            set { this.newsArticles = value; }
        }
    }
}
