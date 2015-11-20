namespace CrowdSourcedNews.Api.Controllers
{
    using System.Web.Http;

    using AutoMapper;
    using CrowdSourcedNews.Models;
    using Data.Services.Contracts;  
    using Models.Comment;   

    public class CommentsController : ApiController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }
        
        [Authorize]
        [Route("~/api/newsarticles/comments/{id}")]
        [HttpPost]
        public IHttpActionResult PostComment(int id, [FromBody]CommentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dataModel = Mapper.Map<Comment>(model);

            var commentId = this.comments.Add(id, dataModel, this.User.Identity.Name);

            return this.Ok(commentId);
        }

        [Authorize]
        [Route("~/api/comments/{id}")]
        [HttpPost]
        public IHttpActionResult PostSubComment(int id, [FromBody]CommentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dataModel = Mapper.Map<Comment>(model);

            var commentId = this.comments.AddSubComment(id, dataModel, this.User.Identity.Name);

            return this.Ok(commentId);
        }
    }
}