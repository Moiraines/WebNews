namespace CrowdSourcedNews.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        private ICollection<Comment> subComments;

        public Comment()
        {
            this.subComments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public ICollection<Comment> SubComments
        {
            get { return this.subComments; }
            set { this.subComments = value; }
        }
    }
}
