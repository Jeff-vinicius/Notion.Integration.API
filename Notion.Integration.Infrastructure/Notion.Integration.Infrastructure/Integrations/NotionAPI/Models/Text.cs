using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Text
    {
        public Text(string content)
        {
            Content = content;
        }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
