namespace CrowdSourcedNews.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int SubCommentId { get; set; }

        public virtual Comment SubComment { get; set; }
    }
}
