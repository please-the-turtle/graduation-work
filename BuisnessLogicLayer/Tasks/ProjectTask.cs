using BuisnessLogicLayer.Projects;

namespace BuisnessLogicLayer.Tasks
{
    public partial class ProjectTask
    {
        public ProjectTask()
        {
            InverseParentNavigation = new HashSet<ProjectTask>();
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

        public virtual ProjectTask? ParentNavigation { get; set; }
        public virtual TaskPriority PriorityNavigation { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual TaskStatus StatusNavigation { get; set; } = null!;
        public virtual ICollection<ProjectTask> InverseParentNavigation { get; set; }
        public virtual ICollection<UserAssignedToTask> UserAssignedToTasks { get; set; }
    }
}
