using Notion.Integration.Domain.Models;
using Notion.Integration.Infrastructure.Integrations.NotionAPI;

namespace Notion.Integration.Infrastructure.Services
{
    public class NotionAPIService
    {
        private readonly NotionAPI _notionAPI;

        public NotionAPIService()
        {
            if (this._notionAPI == null)
                this._notionAPI = new NotionAPI();
        }

        public async Task<ManagerNotion> CreatePages(List<UserNotion> usersNotion, ManagerNotion managerNotion)
        {
            try
            {
                List<UserNotion> users = new();

                foreach (var user in usersNotion)
                {
                    users.Add(await _notionAPI.CreateUserPage(user));
                }

                return await CreateManagerPage(users, managerNotion);

            }
            catch (Exception ex)
            {

                throw new Exception($"Error creating pages in Notion: {ex}");
            }
        }

        private async Task<ManagerNotion> CreateManagerPage(List<UserNotion> usersNotion, ManagerNotion manager)
        {
            try
            {
                _ = usersNotion.OrderByDescending(u => u.Statistics.TotalPosts);


                return await _notionAPI.CreateManagerPage(usersNotion, manager);

            }
            catch (Exception ex)
            {

                throw new Exception($"Error creating manager page in Notion: {ex}");
            }
        }
    }
}
