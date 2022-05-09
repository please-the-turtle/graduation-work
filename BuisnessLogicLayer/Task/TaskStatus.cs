namespace BuisnessLogicLayer
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        public TaskStatusName Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
