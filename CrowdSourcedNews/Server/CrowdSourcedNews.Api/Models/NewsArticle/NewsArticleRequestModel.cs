namespace CrowdSourcedNews.Api.Models.NewsArticle
{
    using System.ComponentModel.DataAnnotations;

    public class NewsArticleRequestModel
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100000)]
        public string Content { get; set; }
    }
}