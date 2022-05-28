using System.Text.Json.Serialization;

namespace Notion.Integration.API.Models
{
    public class Credentials
    {
        [JsonPropertyName("notion_authorization")]
        public string NotionAuthorization { get; set; }

        [JsonPropertyName("notion_page_id")]
        public string NotionPageId { get; set; }

        [JsonPropertyName("manager_notion")]
        public string ManagerNotion { get; set; }
    }
}
