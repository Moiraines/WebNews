namespace CrowdSourcedNews.Api.Models.Storage
{
    using Newtonsoft.Json;

    public class StorageClient
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}
