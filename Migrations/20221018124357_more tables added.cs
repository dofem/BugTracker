using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Migrations
{
    public partial class moretablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugs_platforms_PlatformId",
                table: "bugs");

            migrationBuilder.DropTable(
                name: "platforms");

            migrationBuilder.DropIndex(
                name: "IX_bugs_PlatformId",
                table: "bugs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bugs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "bugs",
                newName: "channelId");

            migrationBuilder.CreateTable(
                name: "channels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bugs_channelId",
                table: "bugs",
                column: "channelId");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_userId",
                table: "bugs",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_bugs_channels_channelId",
                table: "bugs",
                column: "channelId",
                principalTable: "channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bugs_users_userId",
                table: "bugs",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugs_channels_channelId",
                table: "bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_bugs_users_userId",
                table: "bugs");

            migrationBuilder.DropTable(
                name: "channels");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_bugs_channelId",
                table: "bugs");

            migrationBuilder.DropIndex(
                name: "IX_bugs_userId",
                table: "bugs");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "bugs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "channelId",
                table: "bugs",
                newName: "PlatformId");

            migrationBuilder.CreateTable(
                name: "platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platforms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bugs_PlatformId",
                table: "bugs",
                column: "PlatformId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bugs_platforms_PlatformId",
                table: "bugs",
                column: "PlatformId",
                principalTable: "platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
