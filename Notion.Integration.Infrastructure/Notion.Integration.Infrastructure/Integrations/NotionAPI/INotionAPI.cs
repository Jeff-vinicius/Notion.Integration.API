using Notion.Integration.Domain.Models;
using Notion.Integration.Infrastructure.Integrations.NotionAPI.Models;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI
{
    public interface INotionAPI
    {
        Task<ManagerNotion> CreateManagerPage(PageRequest request, ManagerNotion manager, string authorization);
        Task<UserNotion> CreateUserPage(PageRequest request, UserNotion user);
    }
}