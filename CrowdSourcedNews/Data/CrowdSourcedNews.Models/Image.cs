namespace CrowdSourcedNews.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Url { get; set; }
    }
}
