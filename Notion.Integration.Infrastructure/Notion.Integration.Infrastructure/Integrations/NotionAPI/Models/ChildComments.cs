using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class ChildComments
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("object")]
        public string Obj { get; set; } = "block";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("bulleted_list_item")]
        public BulletedListItem BulletedListItem { get; set; }
    }
}
