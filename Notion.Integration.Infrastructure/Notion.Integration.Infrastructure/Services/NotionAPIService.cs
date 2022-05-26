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

        public async Task<List<UserNotion>> CreatePages(List<UserNotion> usersNotion)
        {
            try
            {
                List<UserNotion> users = new();

                foreach (var user in usersNotion)
                {
                    users.Add(await _notionAPI.CreateUserPage(user));
                }

                return users;

            }
            catch (Exception ex)
            {

                throw new Exception($"Error creating pages in Notion: {ex}");
            }
        }
    }
}
