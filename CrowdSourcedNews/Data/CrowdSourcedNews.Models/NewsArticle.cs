namespace CrowdSourcedNews.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewsArticle
    {
        private ICollection<Image> images;
        private ICollection<Comment> comments;

        public NewsArticle()
        {
            this.images = new HashSet<Image>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
