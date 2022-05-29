using FluentValidation;
using FluentValidation.Results;

namespace Notion.Integration.Domain.Commands
{
    public class CreateIntegrationCommand : Command
    {
        public Guid Id { get; set; }
        public string NotionAuthorization { get; private set; }
        public string NotionPageId { get; private set; }
        public string ManagerNotion { get; private set; }

        public CreateIntegrationCommand(Guid id, string notionAuthorization, string notionPageId, string managerNotion)
        {
            AggregateId = id;
            Id = id;
            NotionAuthorization = notionAuthorization;
            NotionPageId = notionPageId;
            ManagerNotion = managerNotion;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateIntegrationValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CreateIntegrationValidation : AbstractValidator<CreateIntegrationCommand>
    {
        public CreateIntegrationValidation()
        {
            RuleFor(a => a.NotionAuthorization)
                .NotEqual(string.Empty)
                .WithMessage("Necessário informar o Id de autorização do Notion");

            RuleFor(p => p.NotionPageId)
                .NotEqual(string.Empty)
                .WithMessage("Necessário informar o Id da página de integração do Notion");

            RuleFor(m => m.ManagerNotion)
                .NotEqual(string.Empty)
                .WithMessage("Necessário informar o nome do gerente responsável pela integração");
        }
    }
}
