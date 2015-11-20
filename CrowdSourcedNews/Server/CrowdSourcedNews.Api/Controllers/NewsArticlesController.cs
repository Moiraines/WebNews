namespace CrowdSourcedNews.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common;
    using CrowdSourcedNews.Api.Models.NewsArticle;
    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Models;
    using Google.Apis.Drive.v2;
    using Notification.Services;
    using Providers;   
    
    public class NewsArticlesController : ApiController
    {
        private const int PageSize = 10;

        private readonly INewsArticlesService newsArticles;
        private readonly IPubnubBroadcaster pubnub;

        public NewsArticlesController(INewsArticlesService newsArticles, IPubnubBroadcaster pubnub)
        {
            this.newsArticles = newsArticles;
            this.pubnub = pubnub;
        }

        public IHttpActionResult Get()
        {
            var result = this.newsArticles
                .All()
                .OrderByDescending(ar => ar.CreatedOn)
                .ProjectTo<NewsArticleResponseModel>()
               .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return this.BadRequest("Category name cannot be null or empty.");
            }

            var result = this.newsArticles
                .All()
                .Where(a => a.Category.Name.ToLower() == category.ToLower())
                .ProjectTo<NewsArticleResponseModel>()
                .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var article = this.newsArticles.All().ProjectTo<NewsArticleResponseModel>().FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return this.NotFound();
            }
            
            return this.Ok(article);
        }

        [Authorize]
        public IHttpActionResult Post(NewsArticleRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ////var client = StorageAuthentication.GetUserCredentials();
            ////DriveService service = StorageAuthentication.AuthenticateOauth(client.ClientId, client.ClientSecret, "root");
            var imagesCollection = model.Images;

            if (imagesCollection != null)
            {
                var client = StorageAuthentication.GetUserCredentials();
                DriveService service = StorageAuthentication.AuthenticateOauth(client.ClientId, client.ClientSecret, "root");
            }

            //// the case when image files are uploaded and saved on server hdd (Article should be referenced)
            ////foreach (var image in imagesCollection)
            ////{
            ////    var upload = StorageOperation.UploadFile(service, image.Name, StorageOperation.ParentFolder);
            ////    image.Url = string.Format("https://drive.google.com/uc?id={0}", upload.Id);
            ////}
            //
            //// the case when image files are byte arrays
            ////foreach (var image in imagesCollection)
            ////{
            ////    var upload = StorageOperation.UploadFile(service, new byte[100], StorageOperation.ParentFolder);
            ////    image.Url = string.Format("https://drive.google.com/uc?id={0}", upload.Id);
            ////}
            var dataModel = Mapper.Map<NewsArticle>(model);

            var newArticleId = this.newsArticles.Add(dataModel, this.User.Identity.Name);

            this.pubnub.SendNotification(NotifyConstants.PubnubChannelActivityFeed, string.Format("News article {0} created", dataModel.Name));

            return this.Ok(newArticleId);
        }

        [Authorize]
        [Route("~/api/newsarticles/{id}/positive")]
        [HttpPut]
        public IHttpActionResult PositiveVote(int id)
        {
            this.newsArticles.PositiveVote(id);

            return this.Ok("Positive vote");
        }

        [Authorize]
        [Route("~/api/newsarticles/{id}/negative")]
        [HttpPut]
        public IHttpActionResult NegativeVote(int id)
        {
            this.newsArticles.NegativeVote(id);

            return this.Ok("Negative vote");
        }
    }
}