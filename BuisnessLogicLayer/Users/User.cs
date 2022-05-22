using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Tasks;

namespace BuisnessLogicLayer.Users
{
    public partial class User
    {
        private string _email = null!;
        private string _login = null!;
        private string _passwordHash = null!;

        public User()
        {
            UserAssignedToTasks = new HashSet<UserAssignedToTask>();
            UserRoleOnProjects = new HashSet<UserRoleOnProject>();
        }

        public int Id { get; set; }
        public string Email 
        { 
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }

                _email = value;
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }

                _login = value;
            }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }

                _passwordHash = value;
            }
        }

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
