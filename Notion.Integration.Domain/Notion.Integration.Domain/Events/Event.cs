using MediatR;

namespace Notion.Integration.Domain.Events
{
    public class Event : Message, INotification
    {
    }

    public abstract class Event<TResponse> : Message<TResponse>, INotification
    {
    }
}

