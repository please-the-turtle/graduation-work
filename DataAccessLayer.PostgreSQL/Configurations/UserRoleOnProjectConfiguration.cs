using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.PostgreSQL.Configurations
{
    internal class UserRoleOnProjectConfiguration : IEntityTypeConfiguration<UserRoleOnProject>
    {
        public void Configure(EntityTypeBuilder<UserRoleOnProject> builder)
        {
            builder.HasKey(e => new { e.UserId, e.ProjectId })
                    .HasName("user_role_on_project_pkey");

            builder.ToTable("user_role_on_project");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.Property(e => e.ProjectId).HasColumnName("project_id");

            builder.Property(e => e.Role)
                .HasMaxLength(25)
                .HasColumnName("role")
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRoleName)Enum.Parse(typeof(UserRoleName), v));

            builder.HasOne(d => d.Project)
                .WithMany(p => p.UserRoleOnProjects)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("user_role_on_project_project_id_fkey");

            builder.HasOne(d => d.RoleNavigation)
                .WithMany(p => p.UserRoleOnProjects)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_on_project_role_fkey");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserRoleOnProjects)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_role_on_project_user_id_fkey");
        }
    }
}