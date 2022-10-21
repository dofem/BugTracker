using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Migrations
{
    public partial class yes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_bugs_PlatformId",
                table: "bugs");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "bugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bugs_PlatformId",
                table: "bugs",
                column: "PlatformId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_bugs_PlatformId",
                table: "bugs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "bugs");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_PlatformId",
                table: "bugs",
                column: "PlatformId");
        }
    }
}
