using BuisnessLogicLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.PostgreSQL
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasIndex(e => e.Email, "users_email_key")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.AboutMe)
                .HasMaxLength(500)
                .HasColumnName("about_me");

            builder.Property(e => e.DateOfBirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_birth");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");

            builder.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");

            builder.Property(e => e.Login)
                .HasMaxLength(25)
                .HasColumnName("login");

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .HasColumnName("password_hash");

            builder.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");

            builder.Property(e => e.PictureUrl)
                .HasMaxLength(500)
                .HasColumnName("picture_url");
        }
    }
}