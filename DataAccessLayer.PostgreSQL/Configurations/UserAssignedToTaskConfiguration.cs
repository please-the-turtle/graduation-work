using BuisnessLogicLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.PostgreSQL
{
    internal class UserAssignedToTaskConfiguration : IEntityTypeConfiguration<UserAssignedToTask>
    {
        public void Configure(EntityTypeBuilder<UserAssignedToTask> builder)
        {
            builder.HasKey(e => new { e.UserId, e.TaskId })
                   .HasName("user_assigned_to_task_pkey");

            builder.ToTable("user_assigned_to_task");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.Property(e => e.TaskId).HasColumnName("task_id");

            builder.Property(e => e.SpentTime).HasColumnName("spent_time");

            builder.HasOne(d => d.Task)
                .WithMany(p => p.UserAssignedToTasks)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("user_assigned_to_task_task_id_fkey");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserAssignedToTasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_assigned_to_task_user_id_fkey");
        }
    }
}