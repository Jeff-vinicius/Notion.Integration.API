using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class ToDo
    {
        public ToDo(string content, bool toDoCheck)
        {
            RichText.Add(new RichText(content));
            Check = toDoCheck;
        }

        [JsonPropertyName("rich_text")]
        public List<RichText> RichText { get; set; } = new List<RichText>();

        [JsonPropertyName("checked")]
        public bool Check { get; set; }
    }
}
