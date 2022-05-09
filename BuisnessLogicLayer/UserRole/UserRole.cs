namespace BuisnessLogicLayer
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
