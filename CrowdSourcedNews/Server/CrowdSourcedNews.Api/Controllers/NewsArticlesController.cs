﻿namespace CrowdSourcedNews.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CrowdSourcedNews.Api.Models.NewsArticle;
    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Models;
    using Google.Apis.Drive.v2;
    using Providers;
    using Models.Comment;
    using System.Web.Http.Cors;

    public class NewsArticlesController : ApiController
    {
        private readonly INewsArticlesService newsArticles;
        private const int PageSize = 10;

        public NewsArticlesController(INewsArticlesService newsArticles)
        {
            this.newsArticles = newsArticles;
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

            return Ok(article);
        }

        [Authorize]
        public IHttpActionResult Post(NewsArticleRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            //var client = StorageAuthentication.GetUserCredentials();
            //DriveService service = StorageAuthentication.AuthenticateOauth(client.ClientId, client.ClientSecret, "root");
            //var imagesCollection = model.Images;

            if (imagesCollection != null)
            {
                var client = StorageAuthentication.GetUserCredentials();
                DriveService service = StorageAuthentication.AuthenticateOauth(client.ClientId, client.ClientSecret, "root");
            }

            // the case when image files are uploaded and saved on server hdd (Article should be referenced)
            //foreach (var image in imagesCollection)
            //{
            //    var upload = StorageOperation.UploadFile(service, image.Name, StorageOperation.ParentFolder);
            //    image.Url = string.Format("https://drive.google.com/uc?id={0}", upload.Id);
            //}

            // the case when image files are byte arrays
            //foreach (var image in imagesCollection)
            //{
            //    var upload = StorageOperation.UploadFile(service, new byte[100], StorageOperation.ParentFolder);
            //    image.Url = string.Format("https://drive.google.com/uc?id={0}", upload.Id);
            //}

            var dataModel = Mapper.Map<NewsArticle>(model);
            
            var newArticleId = this.newsArticles.Add(dataModel, this.User.Identity.Name);

            return this.Ok(newArticleId);
        }
    }
}