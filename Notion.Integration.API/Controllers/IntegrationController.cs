using Microsoft.AspNetCore.Mvc;
using Notion.Integration.API.Models;
using Notion.Integration.API.Services;

namespace Notion.Integration.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : ControllerBase
    {
        private readonly IIntegrationService _integrationService;

        public IntegrationController(IIntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] Credentials credentials)
        {
            try
            {
                var response = await _integrationService.CreateIntegration(credentials);

                return Created(string.Empty, response.PageManageId);
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex}");
            }
        }
    }
}
