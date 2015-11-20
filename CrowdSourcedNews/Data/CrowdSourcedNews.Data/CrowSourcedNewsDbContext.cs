namespace CrowdSourcedNews.Data
{
    using System.Data.Entity;
    using CrowdSourcedNews.Models;
    using Microsoft.AspNet.Identity.EntityFramework;  

    public class CrowdSourcedNewsDbContext : IdentityDbContext<User>, ICrowdSourcedNewsDbContext
    {
        public CrowdSourcedNewsDbContext()
            : base("AzureConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<NewsArticle> NewsArticles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public static CrowdSourcedNewsDbContext Create()
        {
            return new CrowdSourcedNewsDbContext();
        }
    }
}
