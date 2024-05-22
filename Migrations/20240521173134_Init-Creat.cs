using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demoTest.Migrations
{
    /// <inheritdoc />
    public partial class InitCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "requestId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_requestId",
                table: "Requests",
                column: "requestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Requests_requestId",
                table: "Requests",
                column: "requestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Requests_requestId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_requestId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "requestId",
                table: "Requests");
        }
    }
}
