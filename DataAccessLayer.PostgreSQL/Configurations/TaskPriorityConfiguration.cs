using BuisnessLogicLayer.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.PostgreSQL.Configurations
{
    internal class TaskPriorityConfiguration : IEntityTypeConfiguration<TaskPriority>
    {
        public void Configure(EntityTypeBuilder<TaskPriority> builder)
        {
            builder.HasKey(e => e.Name)
                    .HasName("task_priorities_pkey");

            builder.ToTable("task_priorities");

            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name")
                .HasConversion(
                    v => v.ToString(),
                    v => (TaskPriorityName)Enum.Parse(typeof(TaskPriorityName), v));

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            FillTable(builder);
        }

        private void FillTable(EntityTypeBuilder<TaskPriority> builder)
        {
            builder.HasData(new TaskPriority { Name = TaskPriorityName.Low, Description = "Task has low priority." });
            builder.HasData(new TaskPriority { Name = TaskPriorityName.Medium, Description = "Task has regular priority." });
            builder.HasData(new TaskPriority { Name = TaskPriorityName.High, Description = "Task has high priority." });
            builder.HasData(new TaskPriority { Name = TaskPriorityName.VeryHigh, Description = "One of the most important tasks." });
        }
    }
}