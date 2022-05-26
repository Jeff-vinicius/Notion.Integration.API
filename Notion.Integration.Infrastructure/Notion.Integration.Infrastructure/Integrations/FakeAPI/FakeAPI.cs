using Flurl.Http;
using Flurl;
using Notion.Integration.Infrastructure.Integrations.FakeAPI.Models;
using Notion.Integration.Domain.Models;

namespace Notion.Integration.Infrastructure.Integrations.FakeAPI
{
    public class FakeAPI
    {
        private const string URL_BASE = "https://jsonplaceholder.typicode.com/";

        public async Task<List<UserFake>> GetAllUsers()
        {
            try
            {
                var response = await URL_BASE
                    .AppendPathSegment("users")
                    .WithTimeout(TimeSpan.FromSeconds(20))
                    .GetJsonAsync<IEnumerable<User>>();

                List<UserFake> users = new();

                foreach (var item in response)
                {
                    users.Add(new UserFake()
                    {
                        UserId = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        Phone = item.Phone,
                        Company = item.Company.Name,
                        City = item.Address.City
                    });
                }

                return users;

            }
            catch (FlurlHttpTimeoutException)
            {
                throw new Exception("Request timed out.");

            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new Exception(message, ex);
            }
        }

        public async Task<List<ToDoFake>> GetToDosByUser(int userId)
        {
            try
            {
                var response = await URL_BASE
                    .AppendPathSegment("todos")
                    .SetQueryParam("userId", new[] { userId })
                    .WithTimeout(TimeSpan.FromSeconds(15))
                    .GetJsonAsync<IEnumerable<ToDo>>();

                List<ToDoFake> toDos = new();

                foreach (var item in response)
                {
                    toDos.Add(new ToDoFake()
                    {
                        ToDoId = item.Id,
                        Title = item.Title,
                        Completed = item.Completed,
                    });
                }

                return toDos;

            }
            catch (FlurlHttpTimeoutException)
            {
                throw new Exception("Request timed out.");

            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new Exception(message, ex);
            }
        }

        public async Task<List<PostFake>> GetPostsByUser(int userId)
        {
            try
            {
                var response = await URL_BASE
                    .AppendPathSegment("posts")
                    .SetQueryParam("userId", new[] { userId })
                    .WithTimeout(TimeSpan.FromSeconds(15))
                    .GetJsonAsync<IEnumerable<Post>>();

                List<PostFake> posts = new();

                foreach (var item in response)
                {
                    posts.Add(new PostFake()
                    {
                        PostId = item.Id,
                        Title = item.Title,
                        Description = item.Body,
                    });
                }

                return posts;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new Exception("Request timed out.");

            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new Exception(message, ex);
            }
        }

        public async Task<List<CommentFake>> GetCommentsByPost(int? postId)
        {
            try
            {
                var response = await URL_BASE
                   .AppendPathSegment("comments")
                   .SetQueryParam("postId", new[] { postId })
                   .WithTimeout(TimeSpan.FromSeconds(15))
                   .GetJsonAsync<IEnumerable<Comment>>();

                List<CommentFake> comments = new();

                foreach (var item in response)
                {
                    comments.Add(new CommentFake()
                    {
                        CommentId = item.Id,
                        Title = item.Name,
                        Description = item.Body,
                        Email = item.Email
                    });
                }

                return comments;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new Exception("Request timed out.");

            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new Exception(message, ex);
            }
        }
    }
}
