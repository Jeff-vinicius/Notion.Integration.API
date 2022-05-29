using Notion.Integration.Domain.Events;

namespace Notion.Integration.Domain.Notifications
{
    public class Notification : Event<bool>
    {
        public Guid NotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public Notification(string key, string value)
        {
            NotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }
    }
}
