namespace Notion.Integration.Domain.Exceptions
{
    public class FakeAPIException : Exception
    {
        public FakeAPIException(string message) : base(message)
        {
        }

        public FakeAPIException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
