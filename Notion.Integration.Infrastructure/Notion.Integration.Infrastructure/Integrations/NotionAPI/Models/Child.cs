using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Child
    {
        public Child(string typeChild, string content, bool? toDoCheck, List<ChildComments> childComments, List<ChildTable> childTable)
        {
            Type = typeChild;

            switch (typeChild)
            {
                case "heading_1":
                    Heading1 = new Heading1(content);
                    break;

                case "paragraph":
                    Paragraph = new Paragraph(content);
                    break;

                case "divider":
                    Divider = new Divider();
                    break;

                case "to_do":
                    ToDo = new ToDo(content, toDoCheck.Value);
                    break;

                case "bulleted_list_item":
                    BulletedListItem = new BulletedListItem(content);
                    break;

                case "toggle":
                    Toggle = new Toggle(content, childComments);
                    break;

                case "table":
                    Table = new Table(childTable);
                    break;

                default:
                    throw new Exception("Unidentified Type");
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("object")]
        public string Obj { get; set; } = "block";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("heading_1")]
        public Heading1 Heading1 { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("paragraph")]
        public Paragraph Paragraph { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("divider")]
        public Divider Divider { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("to_do")]
        public ToDo ToDo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("toggle")]
        public Toggle Toggle { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("table")]
        public Table Table { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("bulleted_list_item")]
        public BulletedListItem BulletedListItem { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("table_row")]
        public TableRow TableRow { get; set; }
    }
}
