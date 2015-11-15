namespace CrowdSourcedNews.Api.Models.NewsArticle
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using CrowdSourcedNews.Api.Infrastructure.Mappings;
    using CrowdSourcedNews.Models;

    public class NewsArticleResponseModel : IMapFrom<NewsArticle>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<NewsArticle, NewsArticleResponseModel>()
                .ForMember(p => p.Author, opts => opts.MapFrom(p => p.Author.UserName));
        }
    }
}