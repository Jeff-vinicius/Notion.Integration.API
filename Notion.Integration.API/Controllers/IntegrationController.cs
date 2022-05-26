using Microsoft.AspNetCore.Mvc;
using Notion.Integration.API.Models;
using Notion.Integration.API.Services;

namespace Notion.Integration.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : ControllerBase
    {
        private readonly ILogger<IntegrationController> _logger;

        public IntegrationController(ILogger<IntegrationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] Credentials credentials)
        {
            try
            {
                IntegrationService integrationService = new();
                await integrationService.CreateIntegration(credentials);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex}");
            }
        }
    }
}
