namespace CrowdSourcedNews.Api.Models.NewsArticle
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using CrowdSourcedNews.Api.Infrastructure.Mappings;
    using CrowdSourcedNews.Models;

    public class NewsArticleRequestModel : IMapFrom<NewsArticle>, IHaveCustomMappings
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100000)]
        public string Content { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<NewsArticleRequestModel, NewsArticle>().ForMember(p => p.CreatedOn, opts => opts.UseValue(DateTime.Now));
        }
    }
}