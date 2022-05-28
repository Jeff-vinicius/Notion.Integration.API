using Notion.Integration.Domain.Models;

namespace Notion.Integration.Infrastructure.Services
{
    public interface INotionAPIService
    {
        Task<ManagerNotion> CreatePages(List<UserNotion> usersNotion, ManagerNotion managerNotion);
    }
}