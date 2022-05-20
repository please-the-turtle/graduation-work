using BuisnessLogicLayer.Tasks;

namespace BuisnessLogicLayer.Projects
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<ProjectTask>();
            UserRoleOnProjects = new HashSet<UserRoleOnProject>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }
        public virtual ICollection<UserRoleOnProject> UserRoleOnProjects { get; set; }
    }
}
