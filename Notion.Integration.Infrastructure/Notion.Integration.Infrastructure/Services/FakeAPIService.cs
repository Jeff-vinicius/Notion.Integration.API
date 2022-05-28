using Notion.Integration.Domain.Models;
using Notion.Integration.Infrastructure.Integrations.FakeAPI;

namespace Notion.Integration.Infrastructure.Services
{
    public class FakeAPIService : IFakeAPIService
    {
        private readonly FakeAPI _fakeAPI;

        public FakeAPIService()
        {
            if (this._fakeAPI == null)
                this._fakeAPI = new FakeAPI();
        }

        public async Task<List<UserFake>> GetFakeUsers()
        {
            try
            {
                List<UserFake> users = new();

                List<UserFake> usersFake = await _fakeAPI.GetAllUsers();

                foreach (var item in usersFake)
                {
                    users.Add(new UserFake
                    {
                        UserId = item.UserId,
                        Name = item.Name,
                        Email = item.Email,
                        Phone = item.Phone,
                        Company = item.Company,
                        City = item.City,
                        ToDos = await _fakeAPI.GetToDosByUser(item.UserId),
                        Posts = await GetPostsAndComments(item.UserId),
                    });
                }
                return users;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting fake users: {ex}");
            }
        }

        private async Task<List<PostFake>> GetPostsAndComments(int userId)
        {
            List<PostFake> posts = new();

            List<PostFake> postsFake = await _fakeAPI.GetPostsByUser(userId);

            foreach (var item in postsFake)
            {
                posts.Add(new PostFake
                {
                    PostId = item.PostId,
                    Title = item.Title,
                    Description = item.Description,
                    Comments = await _fakeAPI.GetCommentsByPost(item.PostId),
                });
            }
            return posts;
        }
    }
}
