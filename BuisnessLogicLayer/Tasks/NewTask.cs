namespace BuisnessLogicLayer.Tasks
{
    public class NewProjectTask
    {
        public string Name { get; set; } = null!;

        public TimeSpan LeadTime { get; set; } = new TimeSpan(10, 0, 0);
    }
}