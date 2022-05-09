using BuisnessLogicLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.PostgreSQL
{
    internal class TaskConfiguration : IEntityTypeConfiguration<BuisnessLogicLayer.Task>
    {
        public void Configure(EntityTypeBuilder<BuisnessLogicLayer.Task> builder)
        {
            builder.ToTable("tasks");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Deadline)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deadline");

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(e => e.LeadTime).HasColumnName("lead_time");

            builder.Property(e => e.Parent).HasColumnName("parent");

            builder.Property(e => e.Priority)
                .HasMaxLength(25)
                .HasColumnName("priority")
                .HasConversion(
                    v => v.ToString(),
                    v => (TaskPriorityName)Enum.Parse(typeof(TaskPriorityName), v)); ;

            builder.Property(e => e.ProjectId).HasColumnName("project_id");

            builder.Property(e => e.Status)
                .HasMaxLength(25)
                .HasColumnName("status");

            builder.HasOne(d => d.ParentNavigation)
                .WithMany(p => p.InverseParentNavigation)
                .HasForeignKey(d => d.Parent)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tasks_parent_fkey");

            builder.HasOne(d => d.PriorityNavigation)
                .WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Priority)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_priority_fkey");

            builder.HasOne(d => d.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("tasks_project_id_fkey");

            builder.HasOne(d => d.StatusNavigation)
                .WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_status_fkey");
        }
    }
}