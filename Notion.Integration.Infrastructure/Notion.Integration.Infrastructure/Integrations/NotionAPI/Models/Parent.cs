using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Parent
    {
        public Parent(string pageId)
        {
            PageId = pageId;
        }

        [JsonPropertyName("page_id")]
        public string PageId { get; set; }
    }
}
