namespace CrowdSourcedNews.Data.Services
{
    using System.Linq;

    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> All()
        {
            var result = this.categories.All();

            return result;
        }
    }
}