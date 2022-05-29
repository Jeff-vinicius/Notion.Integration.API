using Microsoft.AspNetCore.Mvc;
using Notion.Integration.API.Models;
using Notion.Integration.Domain.Commands;
using Notion.Integration.Domain.Mediator;

namespace Notion.Integration.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public IntegrationController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] Credentials credentials)
        {
            var command = new CreateIntegrationCommand(Guid.NewGuid(), credentials.NotionAuthorization, credentials.NotionPageId, credentials.ManagerNotion);

            var result = await _mediatorHandler.SendCommand(command);

            return CustomResponse(result);
        }
    }
}
