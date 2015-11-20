namespace CrowdSourcedNews.Api.Models.Category
{
    using AutoMapper;
    using CrowdSourcedNews.Api.Infrastructure.Mappings; 

    public class CategoriesResponseModel : IMapFrom<CrowdSourcedNews.Models.Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<CrowdSourcedNews.Models.Category, CategoriesResponseModel>();
        }
    }
}