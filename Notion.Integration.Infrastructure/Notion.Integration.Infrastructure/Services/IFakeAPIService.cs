using Notion.Integration.Domain.Models;

namespace Notion.Integration.Infrastructure.Services
{
    public interface IFakeAPIService
    {
        Task<List<UserFake>> GetFakeUsers();
    }
}