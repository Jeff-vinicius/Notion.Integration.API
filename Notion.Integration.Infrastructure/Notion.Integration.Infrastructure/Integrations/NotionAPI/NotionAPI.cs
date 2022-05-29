using Flurl.Http;
using Flurl;
using System.Text.Json;
using Notion.Integration.Infrastructure.Integrations.NotionAPI.Models;
using Notion.Integration.Domain.Models;
using Notion.Integration.Domain.Exceptions;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI
{
    public class NotionAPI : INotionAPI
    {
        private const string URL_BASE = "https://api.notion.com/v1/";

        public async Task<UserNotion> CreateUserPage(PageRequest request, UserNotion user)
        {
            var data = JsonSerializer.Serialize(request);

            try
            {
                var response = await URL_BASE
                    .WithTimeout(TimeSpan.FromSeconds(25))
                    .AppendPathSegment("pages")
                    .WithHeader("Content-Type", "application/json")
                    .WithHeader("Authorization", $"Bearer {user.PageNotion.Authorization}")
                    .WithHeader("Notion-Version", "2022-02-22")
                    .PostStringAsync(data)
                    .ReceiveString();

                var responsePage = JsonSerializer.Deserialize<PageResponse>(response);

                user.PageNotion.PageUserId = responsePage.PageId;
                user.PageNotion.PageUrl = responsePage.PageUrl;

                return user;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new NotionAPIException("Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new NotionAPIException(message, ex);
            }
        }

        public async Task<ManagerNotion> CreateManagerPage(PageRequest request, ManagerNotion manager, string authorization)
        {
            var data = JsonSerializer.Serialize(request);

            try
            {
                var response = await URL_BASE
                    .WithTimeout(TimeSpan.FromSeconds(25))
                    .AppendPathSegment("pages")
                    .WithHeader("Content-Type", "application/json")
                    .WithHeader("Authorization", $"Bearer {authorization}")
                    .WithHeader("Notion-Version", "2022-02-22")
                    .PostStringAsync(data)
                    .ReceiveString();

                var responsePage = JsonSerializer.Deserialize<PageResponse>(response);

                manager.PageManageUrl = responsePage.PageUrl;

                return manager;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new NotionAPIException("Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new NotionAPIException(message, ex);
            }
        }
    }
}
