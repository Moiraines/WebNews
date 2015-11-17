using System.Web.Http;
using CrowdSourcedNews.Api.Providers;
using Google.Apis.Drive.v2;

namespace CrowdSourcedNews.Api.Controllers
{
    public class ImageController : ApiController
    {
        public IHttpActionResult Get()
        {
            var client = StorageAuthentication.GetUserCredentials();
            DriveService service = StorageAuthentication.AuthenticateOauth(client.ClientId, client.ClientSecret, "root");

            string Q = "mimeType = 'application/vnd.google-apps.photo'";
            var newsPictures = StorageOperation.GetFiles(service, Q);

            return this.Ok(newsPictures);
        }
    }
}
