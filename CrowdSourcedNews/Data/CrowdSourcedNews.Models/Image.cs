namespace CrowdSourcedNews.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Url { get; set; }

        public string Name { get; set; }

        public int NewsArticleId { get; set; }

        public virtual NewsArticle Atricle { get; set; }
    }
}
