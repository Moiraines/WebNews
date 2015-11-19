namespace CrowdSourcedNews.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using CrowdSourcedNews.Models;

    public sealed class Configuration : DbMigrationsConfiguration<CrowdSourcedNews.Data.CrowdSourcedNewsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CrowdSourcedNewsDbContext context)
        {
            context.Categories.AddOrUpdate(
                  c => c.Name,
                  new Category { Name = "Sports" },
                  new Category { Name = "Politics" },
                  new Category { Name = "Food" },
                  new Category { Name = "International" },
                  new Category { Name = "Local" },
                  new Category { Name = "Business" },
                  new Category { Name = "Economy" },
                  new Category { Name = "Education" },
                  new Category { Name = "Health" },
                  new Category { Name = "Celebrity" }
                  );
        }
    }
}
