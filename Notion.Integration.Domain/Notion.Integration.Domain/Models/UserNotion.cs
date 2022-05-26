namespace Notion.Integration.Domain.Models
{
    public class UserNotion
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public List<TasksNotion> Tasks { get; set; }
        public List<PostNotion> Posts { get; set; }
        public StatisticsNotion Statistics { get; set; }
        public PageNotion PageNotion { get; set; }
    }

    public class TasksNotion
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class PostNotion
    {
        public string Title { get; set; }
        public List<CommentNotion> Comments { get; set; }
    }

    public class CommentNotion
    {
        public string Title { get; set; }
    }

    public class StatisticsNotion
    {
        public string TotalPosts { get; set; }
        public string TotalComments { get; set; }
        public string TotalTasksPending { get; set; }
        public string TotalTasksCompleted { get; set; }
    }

    public class PageNotion
    {
        public string Authorization { get; set; }
        public string PageParentId { get; set; }
        public string PageUserId { get; set; }
        public string PageManageId { get; set; }
        public string PageUrl { get; set; }
    }
}
