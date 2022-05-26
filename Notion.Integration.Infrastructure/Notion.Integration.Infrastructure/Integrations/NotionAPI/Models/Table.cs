using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Table
    {
        public Table(List<ChildTable> childTable)
        {
            Children = childTable;
        }

        [JsonPropertyName("table_width")]
        public int TableWidth { get; set; } = 4;

        [JsonPropertyName("has_column_header")]
        public bool HasColumnHeader { get; set; } = true;

        [JsonPropertyName("has_row_header")]
        public bool HasRowHeader { get; set; } = false;

        [JsonPropertyName("children")]
        public List<ChildTable> Children { get; set; } = new List<ChildTable>();
    }
}
