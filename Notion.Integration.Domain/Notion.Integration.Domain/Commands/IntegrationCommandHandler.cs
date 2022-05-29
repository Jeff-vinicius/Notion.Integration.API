using MediatR;
using Notion.Integration.Domain.Interfaces;
using Notion.Integration.Domain.Models;
using Notion.Integration.Domain.Notifications;

namespace Notion.Integration.Domain.Commands
{
    public class IntegrationCommandHandler : CommandHandler,
       IRequestHandler<CreateIntegrationCommand, IntegrationResponse>
    {
        private readonly IIntegrationNotionRepository _integrationNotionRepository;

        public IntegrationCommandHandler(IMediator mediator, IIntegrationNotionRepository integrationNotionRepository) : base(mediator)
        {
            _integrationNotionRepository = integrationNotionRepository;
        }

        public async Task<IntegrationResponse> Handle(CreateIntegrationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid)
            {
                NotifyValidationErrors(request);
                return new IntegrationResponse();
            } 

            var integration = new IntegrationNotion(request.Id, request.NotionAuthorization, request.NotionPageId, request.ManagerNotion);

            var pageManager = await _integrationNotionRepository.CreateIntegrationNotion(integration);

            if (pageManager.PageManageUrl == null)
            {
                await Mediator.Publish(new Notification("", "Houve um erro na integração, entre em contato com o administrador!"));

                return new IntegrationResponse();
            }

            return new IntegrationResponse
            {
                ManagerPageUrl = pageManager.PageManageUrl,
            };
        }
    }
}
