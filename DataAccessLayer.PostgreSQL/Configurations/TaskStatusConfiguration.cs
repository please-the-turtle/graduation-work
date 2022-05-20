using BuisnessLogicLayer.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskStatus = BuisnessLogicLayer.Tasks.TaskStatus;

namespace DataAccessLayer.PostgreSQL.Configurations
{
    internal class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> builder)
        {
            builder.HasKey(e => e.Name)
                    .HasName("task_statuses_pkey");

            builder.ToTable("task_statuses");

            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name")
                .HasConversion(
                    v => v.ToString(),
                    v => (TaskStatusName)Enum.Parse(typeof(TaskStatusName), v));

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            FillTable(builder);
        }

        // TODO Hardcoding
        private void FillTable(EntityTypeBuilder<TaskStatus> builder)
        {
            builder.HasData(new TaskStatus { Name = TaskStatusName.NotAtWork, Description = "No one is currently working on the task." });
            builder.HasData(new TaskStatus { Name = TaskStatusName.InQueue, Description = "Task queued for execution." });
            builder.HasData(new TaskStatus { Name = TaskStatusName.InProgress, Description = "Task in progress." });
            builder.HasData(new TaskStatus { Name = TaskStatusName.Completed, Description = "Task completed." });
            builder.HasData(new TaskStatus { Name = TaskStatusName.Correcting, Description = "Task in progress." });
        }
    }
}