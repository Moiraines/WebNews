namespace CrowdSourcedNews.Data
{
    using CrowdSourcedNews.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class CrowdSourcedNewsDbContext : IdentityDbContext<User>, ICrowdSourcedNewsDbContext
    {
        public CrowdSourcedNewsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<NewsArticle> NewsArticles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static CrowdSourcedNewsDbContext Create()
        {
            return new CrowdSourcedNewsDbContext();
        }
    }
}
