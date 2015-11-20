namespace CrowdSourcedNews.Api.Models.Comment
{
    using System.ComponentModel.DataAnnotations;

    using CrowdSourcedNews.Models;
    using Infrastructure.Mappings;     

    public class CommentRequestModel : IMapFrom<Comment>
    {
        [Required]
        [MaxLength(10000)]
        public string Content { get; set; }
    }
}