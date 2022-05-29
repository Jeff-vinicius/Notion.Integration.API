namespace Notion.Integration.Domain.Exceptions
{
    public class NotionAPIException : Exception
    {
        public NotionAPIException(string message) : base(message)
        {
        }

        public NotionAPIException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
