namespace CrowdSourcedNews.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
        
        public int SubCommentId { get; set; }
    }
}
