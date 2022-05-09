namespace BuisnessLogicLayer
{
    public partial class TaskPriority
    {
        public TaskPriority()
        {
            Tasks = new HashSet<Task>();
        }

        public TaskPriorityName Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
