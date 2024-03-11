using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerTarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class novoscampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogTasks_TasksProject_TaskProjectTaskID",
                table: "LogTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_LogTasks_UsersAccount_UserID",
                table: "LogTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksProject_Projects_ProjectID",
                table: "TasksProject");

            migrationBuilder.DropIndex(
                name: "IX_TasksProject_ProjectID",
                table: "TasksProject");

            migrationBuilder.DropIndex(
                name: "IX_LogTasks_UserID",
                table: "LogTasks");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "LogTasks");

            migrationBuilder.RenameColumn(
                name: "TaskProjectTaskID",
                table: "LogTasks",
                newName: "UserAccountUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LogTasks_TaskProjectTaskID",
                table: "LogTasks",
                newName: "IX_LogTasks_UserAccountUserId");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TasksProject",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LogTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_LogTasks_UsersAccount_UserAccountUserId",
                table: "LogTasks",
                column: "UserAccountUserId",
                principalTable: "UsersAccount",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogTasks_UsersAccount_UserAccountUserId",
                table: "LogTasks");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TasksProject");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LogTasks");

            migrationBuilder.RenameColumn(
                name: "UserAccountUserId",
                table: "LogTasks",
                newName: "TaskProjectTaskID");

            migrationBuilder.RenameIndex(
                name: "IX_LogTasks_UserAccountUserId",
                table: "LogTasks",
                newName: "IX_LogTasks_TaskProjectTaskID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "LogTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TasksProject_ProjectID",
                table: "TasksProject",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_LogTasks_UserID",
                table: "LogTasks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogTasks_TasksProject_TaskProjectTaskID",
                table: "LogTasks",
                column: "TaskProjectTaskID",
                principalTable: "TasksProject",
                principalColumn: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogTasks_UsersAccount_UserID",
                table: "LogTasks",
                column: "UserID",
                principalTable: "UsersAccount",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksProject_Projects_ProjectID",
                table: "TasksProject",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
