using MediatR;
using Notion.Integration.Domain.Notifications;

namespace Notion.Integration.Domain.Commands
{
    public abstract class CommandHandler
    {
        public IMediator Mediator { get; private set; }

        protected CommandHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected void NotifyValidationErrors(Command command)
        {
            foreach (var error in command?.ValidationResult?.Errors) Mediator.Publish(new Notification("", error.ErrorMessage));
        }

        protected void NotifyValidationErrors<TResponse>(Command<TResponse> command)
        {

        }
    }
}
