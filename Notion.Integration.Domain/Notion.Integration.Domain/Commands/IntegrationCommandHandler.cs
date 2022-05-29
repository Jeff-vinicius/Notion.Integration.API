using FluentValidation.Results;
using MediatR;
using Notion.Integration.Domain.Interfaces;
using Notion.Integration.Domain.Models;

namespace Notion.Integration.Domain.Commands
{
    public class IntegrationCommandHandler : CommandHandler,
        IRequestHandler<CreateIntegrationCommand, ValidationResult>
    {
        private readonly IIntegrationNotionRepository _integrationNotionRepository;

        public IntegrationCommandHandler(IIntegrationNotionRepository integrationNotionRepository)
        {
            _integrationNotionRepository = integrationNotionRepository;
        }

        public async Task<ValidationResult> Handle(CreateIntegrationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var integration = new IntegrationNotion(request.Id, request.NotionAuthorization, request.NotionPageId, request.ManagerNotion);

            var pageManager =  await _integrationNotionRepository.CreateIntegrationNotion(integration);

            if(pageManager.PageManageUrl == null)
            {
                AddError("Houve um erro na integração, entre em contato com o administrador!");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
