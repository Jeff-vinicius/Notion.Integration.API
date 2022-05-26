using Notion.Integration.API.Models;
using Notion.Integration.Domain.Models;
using Notion.Integration.Infrastructure.Services;

namespace Notion.Integration.API.Services
{
    public class IntegrationService
    {
        private readonly FakeAPIService _fakeAPIService;
        private readonly NotionAPIService _notionAPIService;

        public IntegrationService()
        {
            if (this._fakeAPIService == null)
                this._fakeAPIService = new FakeAPIService();

            if (this._notionAPIService == null)
                this._notionAPIService = new NotionAPIService();
        }

        public async Task CreateIntegration(Credentials credentials)
        {
            try
            {
                List<UserFake> fakeUsers = await _fakeAPIService.GetFakeUsers();

                await CreateNotionIntegration(credentials, fakeUsers);

            }
            catch (Exception ex)
            {

                throw new Exception($"There was an error in the integration: {ex}");
            }
        }

        #region Notion
        private async Task CreateNotionIntegration(Credentials credentials, List<UserFake> fakeUsers)
        {
            List<UserNotion> notionUsers = new();

            foreach (var user in fakeUsers)
            {
                notionUsers.Add(new UserNotion()
                {
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    Company = user.Company,
                    City = user.City,
                    Tasks = GetTasks(user.ToDos),
                    Posts = GetPosts(user.Posts),
                    Statistics = GetStatistics(user),
                    PageNotion = new PageNotion()
                    {
                        Authorization = credentials.NotionAuthorization,
                        PageParentId = credentials.NotionPageId
                    }
                });
            }

            List<UserNotion> resultNotion = await _notionAPIService.CreatePages(notionUsers);
        }

        private static List<TasksNotion> GetTasks(List<ToDoFake> toDos)
        {
            List<TasksNotion> tasks = new();

            foreach (var toDo in toDos)
            {
                tasks.Add(new TasksNotion()
                {
                    Title = toDo.Title,
                    Completed = toDo.Completed,
                });
            }
            return tasks;
        }

        private static List<PostNotion> GetPosts(List<PostFake> posts)
        {
            List<PostNotion> notionPosts = new();

            foreach (var post in posts)
            {
                notionPosts.Add(new PostNotion()
                {
                    Title = post.Title,
                    Comments = GetComments(post.Comments)
                });
            }
            return notionPosts;
        }

        private static List<CommentNotion> GetComments(List<CommentFake> comments)
        {
            List<CommentNotion> notionComments = new();

            foreach (var comment in comments)
            {
                notionComments.Add(new CommentNotion()
                {
                    Title = comment.Title,
                });
            }
            return notionComments;
        }

        private static StatisticsNotion GetStatistics(UserFake userFake)
        {
            int totalComments = 0;
            int totalTasksPending = 0;
            int totalTasksCompleted = 0;

            foreach (var post in userFake.Posts)
            {
                totalComments += post.Comments.Count;
            };

            foreach (var task in userFake.ToDos)
            {
                if (task.Completed)
                    totalTasksCompleted++;
                else
                    totalTasksPending++;
            }

            StatisticsNotion statistics = new()
            {
                TotalPosts = userFake.Posts.Count.ToString(),
                TotalComments = totalComments.ToString(),
                TotalTasksCompleted = totalTasksCompleted.ToString(),
                TotalTasksPending = totalTasksPending.ToString()
            };
            return statistics;
        }
        #endregion
    }
}

