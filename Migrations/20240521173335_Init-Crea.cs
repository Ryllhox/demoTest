using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demoTest.Migrations
{
    /// <inheritdoc />
    public partial class InitCrea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Requests_requestId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "requestId",
                table: "Requests",
                newName: "PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_requestId",
                table: "Requests",
                newName: "IX_Requests_PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Priorities_PriorityId",
                table: "Requests",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Priorities_PriorityId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Requests",
                newName: "requestId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_PriorityId",
                table: "Requests",
                newName: "IX_Requests_requestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Requests_requestId",
                table: "Requests",
                column: "requestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }
    }
}
