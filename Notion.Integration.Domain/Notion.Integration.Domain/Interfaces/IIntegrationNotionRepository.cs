using Notion.Integration.Domain.Models;

namespace Notion.Integration.Domain.Interfaces
{
    public interface IIntegrationNotionRepository
    {
        Task<ManagerNotion> CreateIntegrationNotion(IntegrationNotion integrationNotion);
    }
}
