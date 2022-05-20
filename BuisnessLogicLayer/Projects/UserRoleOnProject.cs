using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Projects
{
    public partial class UserRoleOnProject
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public UserRoleName Role { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual UserRole RoleNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
