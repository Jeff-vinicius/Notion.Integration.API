using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class PageRequest
    {
        public void AddParentPageId(string pageId)
        {
            Parent = new Parent(pageId);
        }

        public void AddPropertieTitle(string content)
        {
            Properties = new Properties(content);
        }

        public void AddChild(string typeChild, string content, bool? toDoCheck, List<ChildComments> childComments, List<ChildTable> childTable)
        {
            Children.Add(new Child(typeChild, content, toDoCheck, childComments, childTable));
        }

        [JsonPropertyName("parent")]
        public Parent Parent { get; set; }

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("children")]
        public List<Child> Children { get; set; } = new List<Child>();
    }
}
