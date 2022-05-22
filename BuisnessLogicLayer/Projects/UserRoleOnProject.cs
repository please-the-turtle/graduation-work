using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Projects
{
    public partial class UserRoleOnProject
    {
        private int _userId;
        private int _projectId;

        public UserRoleOnProject(int userId, int projectId, UserRoleName userRoleName = UserRoleName.User)
        {
            UserId = userId;
            ProjectId = projectId;
            Role = userRoleName;
        }

        public UserRoleOnProject() { }

        public int UserId
        {
            get => _userId;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "User id must be greater than zero.");
                }

                _userId = value;
            }
        }

        public int ProjectId
        {
            get => _projectId;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Project id must be greater than zero.");
                }

                _projectId = value;
            }

        }

        public UserRoleName Role { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual UserRole RoleNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
