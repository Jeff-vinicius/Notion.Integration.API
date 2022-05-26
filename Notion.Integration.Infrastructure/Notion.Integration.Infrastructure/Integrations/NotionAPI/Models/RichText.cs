using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class RichText
    {
        public RichText(string content)
        {
            Text = new Text(content);
        }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "text";

        [JsonPropertyName("text")]
        public Text Text { get; set; }
    }
}
