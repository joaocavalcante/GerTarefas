using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerTarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modificacoes_log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "LogTasks",
                newName: "History");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "History",
                table: "LogTasks",
                newName: "Description");
        }
    }
}
