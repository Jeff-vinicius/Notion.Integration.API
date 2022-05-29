using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notion.Integration.API.Models;
using Notion.Integration.Domain.Commands;

namespace Notion.Integration.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : MainController
    {
        private readonly IMediator _mediator;

        public IntegrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] Credentials credentials)
        {
            var command = new CreateIntegrationCommand(Guid.NewGuid(), credentials.NotionAuthorization, credentials.NotionPageId, credentials.ManagerNotion);

            var result = await _mediator.Send(command);

            return CustomResponse(result.ManagerPageUrl);
        }
    }
}
