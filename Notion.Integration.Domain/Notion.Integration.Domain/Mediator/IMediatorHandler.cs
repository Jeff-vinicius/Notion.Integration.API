using FluentValidation.Results;
using Notion.Integration.Domain.Commands;
using Notion.Integration.Domain.Events;

namespace Notion.Integration.Domain.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where  T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command; 
    }
}
