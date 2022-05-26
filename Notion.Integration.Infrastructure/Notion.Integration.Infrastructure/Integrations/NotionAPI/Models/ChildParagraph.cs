using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class ChildParagraph
    {
        public ChildParagraph(string typeObj, string content)
        {
            Type = typeObj;
            Paragraph = new Paragraph(content);
        }

        [JsonPropertyName("object")]
        public string Obj { get; set; } = "block";

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("paragraph")]
        public Paragraph Paragraph { get; set; }
    }
}
