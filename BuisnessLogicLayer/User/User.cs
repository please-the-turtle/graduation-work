namespace BuisnessLogicLayer
{
    public partial class User
    {
        public User()
        {
            UserAssignedToTasks = new HashSet<UserAssignedToTask>();
            UserRoleOnProjects = new HashSet<UserRoleOnProject>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Position { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AboutMe { get; set; }
        public string? PictureUrl { get; set; }

        public virtual ICollection<UserAssignedToTask> UserAssignedToTasks { get; set; }
        public virtual ICollection<UserRoleOnProject> UserRoleOnProjects { get; set; }
    }
}
