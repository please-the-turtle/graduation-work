using BuisnessLogicLayer.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.PostgreSQL.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => e.Name)
                    .HasName("user_roles_pkey");

            builder.ToTable("user_roles");

            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name")
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRoleName)Enum.Parse(typeof(UserRoleName), v));

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            FillTable(builder);
        }

        private void FillTable(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(new UserRole { Name = UserRoleName.Creator, Description = "Creator of the project." });
            builder.HasData(new UserRole { Name = UserRoleName.Moderator, Description = "Moderastor of the project." });
            builder.HasData(new UserRole { Name = UserRoleName.User, Description = "Ordinary user." });
        }
    }
}