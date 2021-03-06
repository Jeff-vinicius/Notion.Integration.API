using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Heading1
    {
        public Heading1(string content)
        {
            RichText.Add(new RichText(content));
        }

        [JsonPropertyName("rich_text")]
        public List<RichText> RichText { get; set; } = new List<RichText>();
    }
}
