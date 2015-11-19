namespace CrowdSourcedNews.Notification.Services
{
    using Common;
    using PubNubMessaging.Core;

    public class PubnubBroadcaster : IPubnubBroadcaster
    {
        private readonly Pubnub pubnubClient;

        public PubnubBroadcaster()
        {
            pubnubClient = new Pubnub(Constants.PubnubPublishKey, Constants.PubnubSubscribeKey);
        }

        public void SendNotification(string channel, string message)
        {
            pubnubClient.Publish<string>(channel: channel, message: message, errorCallback: str => { }, userCallback: s => { });
        }
    }
}
