namespace CrowdSourcedNews.Api.Controllers
{
    using System.Web.Http;
    using CrowdSourcedNews.Api.Providers;
    using Google.Apis.Drive.v2;

    public class ImageController : ApiController
    {
        public IHttpActionResult Get()
        {
            var client = StorageAuthentication.GetUserCredentials();
            DriveService service = StorageAuthentication.AuthenticateOauth(client.ClientId, client.ClientSecret, "root");

            string q = "mimeType = 'application/vnd.google-apps.photo'";
            var newsPictures = StorageOperation.GetFiles(service, q);

            return this.Ok(newsPictures);
        }
    }
}
