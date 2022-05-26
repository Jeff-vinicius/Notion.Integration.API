using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class TableRow
    {
        public TableRow(List<Cells> cells)
        {
            foreach (var cell in cells)
            {
                List<Cells> subList = new()
                {
                    cell
                };
                Cells.Add(subList);
            }

        }

        [JsonPropertyName("cells")]
        public List<List<Cells>> Cells { get; set; } = new List<List<Cells>>();
    }
}
