using Notion.Integration.API.Models;
using Notion.Integration.Domain.Models;

namespace Notion.Integration.API.Services
{
    public interface IIntegrationService
    {
        Task <ManagerNotion> CreateIntegration(Credentials credentials);
    }
}
