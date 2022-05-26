using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Toggle
    {
        public Toggle(string content, List<ChildComments> childComments)
        {
            RichText.Add(new RichText(content));
            Children = childComments;
        }

        [JsonPropertyName("rich_text")]
        public List<RichText> RichText { get; set; } = new List<RichText>();

        [JsonPropertyName("children")]
        public List<ChildComments> Children { get; set; } = new List<ChildComments>();
    }
}
