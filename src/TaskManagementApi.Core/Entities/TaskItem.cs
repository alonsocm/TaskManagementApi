namespace TaskManagementApi.Core.Entities
{
    namespace TaskManagementApi.Core.Entities
    {
        public enum Priority
        {
            High,
            Medium,
            Low
        }

        public enum Status
        {
            Pending,
            Completed
        }

        public class TaskItem
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Title { get; set; }
            public string Description { get; set; }
            public Priority Priority { get; set; }
            public Status Status { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        }
    }
}
