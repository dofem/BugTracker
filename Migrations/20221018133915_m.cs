using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugs_channels_channelId",
                table: "bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_bugs_users_userId",
                table: "bugs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "channels",
                newName: "ChannelId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "bugs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "channelId",
                table: "bugs",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_bugs_userId",
                table: "bugs",
                newName: "IX_bugs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bugs_channelId",
                table: "bugs",
                newName: "IX_bugs_ChannelId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bugs_channels_ChannelId",
                table: "bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_bugs_users_UserId",
                table: "bugs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "channels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bugs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "bugs",
                newName: "channelId");

            migrationBuilder.RenameIndex(
                name: "IX_bugs_UserId",
                table: "bugs",
                newName: "IX_bugs_userId");

            migrationBuilder.RenameIndex(
                name: "IX_bugs_ChannelId",
                table: "bugs",
                newName: "IX_bugs_channelId");

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
    }
}
