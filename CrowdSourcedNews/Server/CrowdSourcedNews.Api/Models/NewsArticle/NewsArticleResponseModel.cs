namespace CrowdSourcedNews.Api.Models.NewsArticle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CrowdSourcedNews.Models;

    public class NewsArticleResponseModel
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}