using Notion.Integration.Domain.Interfaces;
using Notion.Integration.Domain.Models;
using Notion.Integration.Infrastructure.Services;

namespace Notion.Integration.Infrastructure.Repositories
{
    public class IntegrationNotionRepository : IIntegrationNotionRepository
    {
        private readonly IFakeAPIService _fakeAPIService;
        private readonly INotionAPIService _notionAPIService;

        public IntegrationNotionRepository(IFakeAPIService fakeAPIService, INotionAPIService notionAPIService)
        {
            _fakeAPIService = fakeAPIService;
            _notionAPIService = notionAPIService;
        }

        public async Task<ManagerNotion> CreateIntegrationNotion(IntegrationNotion integrationNotion)
        {
            try
            {
                List<UserFake> fakeUsers = await _fakeAPIService.GetFakeUsers();

                return await CreateNotionIntegration(integrationNotion, fakeUsers);

            }
            catch (Exception ex)
            {

                throw new Exception($"There was an error in the integration: {ex}");
            }
        }

        private async Task<ManagerNotion> CreateNotionIntegration(IntegrationNotion integrationNotion, List<UserFake> fakeUsers)
        {
            List<UserNotion> notionUsers = new();
            ManagerNotion managerNotion = new()
            {
                ManagerName = integrationNotion.ManagerNotion
            };

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
                        Authorization = integrationNotion.NotionAuthorization,
                        PageParentId = integrationNotion.NotionPageId
                    }
                });
            }

            return await _notionAPIService.CreatePages(notionUsers, managerNotion);
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
    }
}
