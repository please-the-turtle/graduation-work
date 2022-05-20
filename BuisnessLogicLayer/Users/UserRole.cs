using BuisnessLogicLayer.Projects;

namespace BuisnessLogicLayer.Users
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserRoleOnProjects = new HashSet<UserRoleOnProject>();
        }

        public UserRoleName Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserRoleOnProject> UserRoleOnProjects { get; set; }
    }
}
