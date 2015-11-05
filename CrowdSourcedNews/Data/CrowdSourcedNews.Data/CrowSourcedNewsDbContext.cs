namespace CrowdSourcedNews.Data
{
    using CrowdSourcedNews.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CrowdSourcedNewsDbContext : IdentityDbContext<User>
    {
        public CrowdSourcedNewsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CrowdSourcedNewsDbContext Create()
        {
            return new CrowdSourcedNewsDbContext();
        }
    }
}
