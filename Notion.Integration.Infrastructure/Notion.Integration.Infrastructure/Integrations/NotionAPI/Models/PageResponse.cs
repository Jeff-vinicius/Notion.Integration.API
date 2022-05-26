using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class PageResponse
    {
        [JsonPropertyName("id")]
        public string PageId { get; set; }

        [JsonPropertyName("url")]
        public string PageUrl { get; set; }
    }
}
