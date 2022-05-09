﻿// <auto-generated />
using System;
using DataAccessLayer.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.PostgreSQL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BuisnessLogicLayer.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("BuisnessLogicLayer.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<TimeSpan>("LeadTime")
                        .HasColumnType("interval")
                        .HasColumnName("lead_time");

                    b.Property<int?>("Parent")
                        .HasColumnType("integer")
                        .HasColumnName("parent");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("priority");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Parent");

                    b.HasIndex("Priority");

                    b.HasIndex("ProjectId");

                    b.HasIndex("Status");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("BuisnessLogicLayer.TaskPriority", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("name");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.HasKey("Name")
                        .HasName("task_priorities_pkey");

                    b.ToTable("task_priorities", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "Low",
                            Description = "Task has low priority."
                        },
                        new
                        {
                            Name = "Medium",
                            Description = "Task has regular priority."
                        },
                        new
                        {
                            Name = "High",
                            Description = "Task has high priority."
                        },
                        new
                        {
                            Name = "VeryHigh",
                            Description = "One of the most important tasks."
                        });
                });

            modelBuilder.Entity("BuisnessLogicLayer.TaskStatus", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("name");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.HasKey("Name")
                        .HasName("task_statuses_pkey");

                    b.ToTable("task_statuses", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "NotAtWork",
                            Description = "No one is currently working on the task."
                        },
                        new
                        {
                            Name = "InQueue",
                            Description = "Task queued for execution."
                        },
                        new
                        {
                            Name = "InProgress",
                            Description = "Task in progress."
                        },
                        new
                        {
                            Name = "Completed",
                            Description = "Task completed."
                        },
                        new
                        {
                            Name = "Correcting",
                            Description = "Task in progress."
                        });
                });

            modelBuilder.Entity("BuisnessLogicLayer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutMe")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("about_me");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("login");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("password_hash");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("picture_url");

                    b.Property<string>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("position");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "users_email_key")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("BuisnessLogicLayer.UserAssignedToTask", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("TaskId")
                        .HasColumnType("integer")
                        .HasColumnName("task_id");

                    b.Property<TimeSpan?>("SpentTime")
                        .HasColumnType("interval")
                        .HasColumnName("spent_time");

                    b.HasKey("UserId", "TaskId")
                        .HasName("user_assigned_to_task_pkey");

                    b.HasIndex("TaskId");

                    b.ToTable("user_assigned_to_task", (string)null);
                });

            modelBuilder.Entity("BuisnessLogicLayer.UserRole", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("name");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.HasKey("Name")
                        .HasName("user_roles_pkey");

                    b.ToTable("user_roles", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "Creator",
                            Description = "Creator of the project."
                        },
                        new
                        {
                            Name = "Moderator",
                            Description = "Moderastor of the project."
                        },
                        new
                        {
                            Name = "User",
                            Description = "Ordinary user."
                        });
                });

            modelBuilder.Entity("BuisnessLogicLayer.UserRoleOnProject", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("role");

                    b.HasKey("UserId", "ProjectId")
                        .HasName("user_role_on_project_pkey");

                    b.HasIndex("ProjectId");

                    b.HasIndex("Role");

                    b.ToTable("user_role_on_project", (string)null);
                });

            modelBuilder.Entity("BuisnessLogicLayer.Task", b =>
                {
                    b.HasOne("BuisnessLogicLayer.Task", "ParentNavigation")
                        .WithMany("InverseParentNavigation")
                        .HasForeignKey("Parent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("tasks_parent_fkey");

                    b.HasOne("BuisnessLogicLayer.TaskPriority", "PriorityNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("Priority")
                        .IsRequired()
                        .HasConstraintName("tasks_priority_fkey");

                    b.HasOne("BuisnessLogicLayer.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tasks_project_id_fkey");

                    b.HasOne("BuisnessLogicLayer.TaskStatus", "StatusNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("Status")
                        .IsRequired()
                        .HasConstraintName("tasks_status_fkey");

                    b.Navigation("ParentNavigation");

                    b.Navigation("PriorityNavigation");

                    b.Navigation("Project");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("BuisnessLogicLayer.UserAssignedToTask", b =>
                {
                    b.HasOne("BuisnessLogicLayer.Task", "Task")
                        .WithMany("UserAssignedToTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_assigned_to_task_task_id_fkey");

                    b.HasOne("BuisnessLogicLayer.User", "User")
                        .WithMany("UserAssignedToTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_assigned_to_task_user_id_fkey");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuisnessLogicLayer.UserRoleOnProject", b =>
                {
                    b.HasOne("BuisnessLogicLayer.Project", "Project")
                        .WithMany("UserRoleOnProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_role_on_project_project_id_fkey");

                    b.HasOne("BuisnessLogicLayer.UserRole", "RoleNavigation")
                        .WithMany("UserRoleOnProjects")
                        .HasForeignKey("Role")
                        .IsRequired()
                        .HasConstraintName("user_role_on_project_role_fkey");

                    b.HasOne("BuisnessLogicLayer.User", "User")
                        .WithMany("UserRoleOnProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_role_on_project_user_id_fkey");

                    b.Navigation("Project");

                    b.Navigation("RoleNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuisnessLogicLayer.Project", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("UserRoleOnProjects");
                });

            modelBuilder.Entity("BuisnessLogicLayer.Task", b =>
                {
                    b.Navigation("InverseParentNavigation");

                    b.Navigation("UserAssignedToTasks");
                });

            modelBuilder.Entity("BuisnessLogicLayer.TaskPriority", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BuisnessLogicLayer.TaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BuisnessLogicLayer.User", b =>
                {
                    b.Navigation("UserAssignedToTasks");

                    b.Navigation("UserRoleOnProjects");
                });

            modelBuilder.Entity("BuisnessLogicLayer.UserRole", b =>
                {
                    b.Navigation("UserRoleOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
