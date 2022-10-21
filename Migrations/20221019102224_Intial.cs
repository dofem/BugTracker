using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugs_channels_ChannelId",
                table: "bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_bugs_users_UserId",
                table: "bugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_channels",
                table: "channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bugs",
                table: "bugs");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "channels",
                newName: "Channels");

            migrationBuilder.RenameTable(
                name: "bugs",
                newName: "Bugs");

            migrationBuilder.RenameIndex(
                name: "IX_bugs_UserId",
                table: "Bugs",
                newName: "IX_Bugs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bugs_ChannelId",
                table: "Bugs",
                newName: "IX_Bugs_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Channels",
                table: "Channels",
                column: "ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bugs",
                table: "Bugs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Channels_ChannelId",
                table: "Bugs",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Users_UserId",
                table: "Bugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Channels_ChannelId",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Users_UserId",
                table: "Bugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Channels",
                table: "Channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bugs",
                table: "Bugs");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Channels",
                newName: "channels");

            migrationBuilder.RenameTable(
                name: "Bugs",
                newName: "bugs");

            migrationBuilder.RenameIndex(
                name: "IX_Bugs_UserId",
                table: "bugs",
                newName: "IX_bugs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bugs_ChannelId",
                table: "bugs",
                newName: "IX_bugs_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_channels",
                table: "channels",
                column: "ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bugs",
                table: "bugs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bugs_channels_ChannelId",
                table: "bugs",
                column: "ChannelId",
                principalTable: "channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bugs_users_UserId",
                table: "bugs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
