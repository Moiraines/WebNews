namespace CrowdSourcedNews.Api.App_Start
{
    using System.Data.Entity;

    using CrowdSourcedNews.Data;
    using Data.Migrations;
    
    public static class DatabaseConfing
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrowdSourcedNewsDbContext, Configuration>());
            CrowdSourcedNewsDbContext.Create().Database.Initialize(true);
        }
    }
}