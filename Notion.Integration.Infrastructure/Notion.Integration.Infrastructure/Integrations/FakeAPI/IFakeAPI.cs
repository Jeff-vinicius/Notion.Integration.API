using Notion.Integration.Domain.Models;

namespace Notion.Integration.Infrastructure.Integrations.FakeAPI
{
    public interface IFakeAPI
    {
        Task<List<UserFake>> GetAllUsers();
        Task<List<CommentFake>> GetCommentsByPost(int? postId);
        Task<List<PostFake>> GetPostsByUser(int userId);
        Task<List<ToDoFake>> GetToDosByUser(int userId);
    }
}