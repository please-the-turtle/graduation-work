namespace BuisnessLogicLayer.Tasks
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<ProjectTask>();
        }

        public TaskStatusName Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
