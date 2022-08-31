using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Tasks;
using BuisnessLogicLayer.Users;
using DataAccessLayer.PostgreSQL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.PostgreSQL
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectTask> Tasks { get; set; } = null!;
        public virtual DbSet<TaskPriority> TaskPriorities { get; set; } = null!;
        public virtual DbSet<BuisnessLogicLayer.Tasks.TaskStatus> TaskStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAssignedToTask> UserAssignedToTasks { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserRoleOnProject> UserRoleOnProjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskPriorityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserAssignedToTaskConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleOnProjectConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
