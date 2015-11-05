namespace CrowdSourcedNews.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<NewsArticle> newsArticles;
        private ICollection<Comment> comments;

        public User()
        {
            this.newsArticles = new HashSet<NewsArticle>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<NewsArticle> NewsArticles
        {
            get { return this.newsArticles; }
            set { this.newsArticles = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
