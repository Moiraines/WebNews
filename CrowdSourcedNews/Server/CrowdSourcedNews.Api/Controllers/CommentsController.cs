namespace CrowdSourcedNews.Api.Controllers
{
    using AutoMapper;
    using Data.Services.Contracts;
    using CrowdSourcedNews.Models;
    using Models.Comment;
    using System.Web.Http;

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

            var commentId = this.comments.Add(id ,dataModel, this.User.Identity.Name);

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