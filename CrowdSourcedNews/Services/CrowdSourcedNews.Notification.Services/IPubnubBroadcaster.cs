namespace CrowdSourcedNews.Notification.Services
{
    public interface IPubnubBroadcaster
    {
        void SendNotification(string channel, string message);
    }
}
