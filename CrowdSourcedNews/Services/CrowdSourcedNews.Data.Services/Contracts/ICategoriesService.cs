namespace CrowdSourcedNews.Data.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface ICategoriesService
    {
        IQueryable<Category> All();
    }
}