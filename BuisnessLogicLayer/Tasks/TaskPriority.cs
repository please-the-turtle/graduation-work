namespace BuisnessLogicLayer.Tasks
{
    public partial class TaskPriority
    {
        public TaskPriority()
        {
            Tasks = new HashSet<ProjectTask>();
        }

        public TaskPriorityName Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
