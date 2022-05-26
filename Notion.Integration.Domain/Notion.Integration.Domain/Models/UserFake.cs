namespace Notion.Integration.Domain.Models
{
    public class UserFake
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public List<ToDoFake> ToDos { get; set; }
        public List<PostFake> Posts { get; set; }
    }

    public class ToDoFake
    {
        public int? ToDoId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class PostFake
    {
        public int? PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CommentFake> Comments { get; set; }
    }

    public class CommentFake
    {
        public int? CommentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
