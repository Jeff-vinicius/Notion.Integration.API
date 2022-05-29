using MediatR;

namespace Notion.Integration.Domain.Events
{
    public abstract class Message : IRequest
    {
    }

    public abstract class Message<TResponse> : IRequest<TResponse>
    {
    }
}
