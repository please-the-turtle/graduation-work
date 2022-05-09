namespace BuisnessLogicLayer
{
    public partial class Task
    {
        public Task()
        {
            InverseParentNavigation = new HashSet<Task>();
            UserAssignedToTasks = new HashSet<UserAssignedToTask>();
        }

        public int Id { get; set; }
        public TaskStatusName Status { get; set; }
        public TaskPriorityName Priority { get; set; }
        public int ProjectId { get; set; }
        public int? Parent { get; set; }
        public string? Description { get; set; }
        public TimeSpan LeadTime { get; set; }
        public DateTime? Deadline { get; set; }

        public virtual Task? ParentNavigation { get; set; }
        public virtual TaskPriority PriorityNavigation { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual TaskStatus StatusNavigation { get; set; } = null!;
        public virtual ICollection<Task> InverseParentNavigation { get; set; }
        public virtual ICollection<UserAssignedToTask> UserAssignedToTasks { get; set; }
    }
}
