using FluentValidation.Results;
using Notion.Integration.Domain.Events;

namespace Notion.Integration.Domain.Commands
{
    public abstract class Command : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid { get; }
    }

    public abstract class Command<TResponse> : Message<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid { get; }
    }
}
