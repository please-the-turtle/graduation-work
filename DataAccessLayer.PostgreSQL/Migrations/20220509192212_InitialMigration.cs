using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.PostgreSQL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_priorities",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("task_priorities_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "task_statuses",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("task_statuses_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_roles_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    login = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    about_me = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    picture_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    status = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    priority = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    project_id = table.Column<int>(type: "integer", nullable: false),
                    parent = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    lead_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    deadline = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                    table.ForeignKey(
                        name: "tasks_parent_fkey",
                        column: x => x.parent,
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tasks_priority_fkey",
                        column: x => x.priority,
                        principalTable: "task_priorities",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "tasks_project_id_fkey",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tasks_status_fkey",
                        column: x => x.status,
                        principalTable: "task_statuses",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "user_role_on_project",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    project_id = table.Column<int>(type: "integer", nullable: false),
                    role = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_role_on_project_pkey", x => new { x.user_id, x.project_id });
                    table.ForeignKey(
                        name: "user_role_on_project_project_id_fkey",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_role_on_project_role_fkey",
                        column: x => x.role,
                        principalTable: "user_roles",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "user_role_on_project_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_assigned_to_task",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    task_id = table.Column<int>(type: "integer", nullable: false),
                    spent_time = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_assigned_to_task_pkey", x => new { x.user_id, x.task_id });
                    table.ForeignKey(
                        name: "user_assigned_to_task_task_id_fkey",
                        column: x => x.task_id,
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_assigned_to_task_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "task_priorities",
                columns: new[] { "name", "description" },
                values: new object[,]
                {
                    { "Low", "Task has low priority." },
                    { "Medium", "Task has regular priority." },
                    { "High", "Task has high priority." },
                    { "VeryHigh", "One of the most important tasks." }
                });

            migrationBuilder.InsertData(
                table: "task_statuses",
                columns: new[] { "name", "description" },
                values: new object[,]
                {
                    { "NotAtWork", "No one is currently working on the task." },
                    { "InQueue", "Task queued for execution." },
                    { "InProgress", "Task in progress." },
                    { "Completed", "Task completed." },
                    { "Correcting", "Task in progress." }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "name", "description" },
                values: new object[,]
                {
                    { "Creator", "Creator of the project." },
                    { "Moderator", "Moderastor of the project." },
                    { "User", "Ordinary user." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_parent",
                table: "tasks",
                column: "parent");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_priority",
                table: "tasks",
                column: "priority");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_project_id",
                table: "tasks",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_status",
                table: "tasks",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_user_assigned_to_task_task_id",
                table: "user_assigned_to_task",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_on_project_project_id",
                table: "user_role_on_project",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_on_project_role",
                table: "user_role_on_project",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_assigned_to_task");

            migrationBuilder.DropTable(
                name: "user_role_on_project");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "task_priorities");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "task_statuses");
        }
    }
}
