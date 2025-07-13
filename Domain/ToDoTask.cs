namespace Domain
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
        public DateTime? DueDate { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public ICollection<TaskFile>? TaskFiles { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public enum TaskStatus
        {
            Pending = 0 ,
            InProgress = 1 ,
            Completed = 2 ,
            Cancelled = 3
        }
    }
}
