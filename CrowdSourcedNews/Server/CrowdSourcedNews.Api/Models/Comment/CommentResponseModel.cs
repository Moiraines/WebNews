namespace CrowdSourcedNews.Api.Models.Comment
{
    using Infrastructure.Mappings;
    using CrowdSourcedNews.Models;
    using System.Collections.Generic;
    using AutoMapper;
    using System;

    public class CommentResponseModel : IMapFrom<NewsArticle>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Content { get; set; }
        
        public string Author { get; set; }

        public ICollection<Comment> SubComments { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Comment, CommentResponseModel>()
                .ForMember(c => c.Author, opts => opts.MapFrom(c => c.Author.UserName));
        }
    }
}