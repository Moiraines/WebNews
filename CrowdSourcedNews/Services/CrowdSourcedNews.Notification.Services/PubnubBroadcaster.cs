namespace CrowdSourcedNews.Notification.Services
{
    using Common;
    using PubNubMessaging.Core;

    public class PubnubBroadcaster : IPubnubBroadcaster
    {
        private readonly Pubnub pubnubClient;

        public PubnubBroadcaster()
            :this(Constants.PubnubPublishKey, Constants.PubnubSubscribeKey)
        { }

        public PubnubBroadcaster(string publishKey, string subscribeKey)
        {
            pubnubClient = new Pubnub(publishKey, subscribeKey);
        }

        public void SendNotification(string channel, string message)
        {
            pubnubClient.Publish<string>(channel: channel, message: message, errorCallback: str => { }, userCallback: s => { });
        }
    }
}
