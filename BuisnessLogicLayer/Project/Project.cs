namespace BuisnessLogicLayer
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
            UserRoleOnProjects = new HashSet<UserRoleOnProject>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<UserRoleOnProject> UserRoleOnProjects { get; set; }
    }
}
