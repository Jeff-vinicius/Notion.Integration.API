using System.Text.Json.Serialization;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI.Models
{
    public class Title
    {
        public Title(string content)
        {
            TitleList.Add(new TitleList(content));
        }

        [JsonPropertyName("title")]
        public List<TitleList> TitleList { get; set; } = new List<TitleList>();
    }
}
