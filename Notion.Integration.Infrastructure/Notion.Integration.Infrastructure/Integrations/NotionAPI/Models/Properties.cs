using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Properties
    {
        public Properties(string content)
        {
            Title = new Title(content);
        }

        [JsonPropertyName("title")]
        public Title Title { get; set; }
    }
}
