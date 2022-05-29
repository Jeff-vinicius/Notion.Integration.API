namespace Notion.Integration.Domain.Models
{
    public class IntegrationNotion
    {
        public IntegrationNotion(Guid id, string notionAuthorization, string notionPageId, string managerNotion)
        {
            Id = id;
            NotionAuthorization = notionAuthorization;
            NotionPageId = notionPageId;
            ManagerNotion = managerNotion;
        }

        public Guid Id { get; set; }
        public string NotionAuthorization { get; private set; }
        public string NotionPageId { get; private set; }
        public string ManagerNotion { get; private set; }
    }
}
