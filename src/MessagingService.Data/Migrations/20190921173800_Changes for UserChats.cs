using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Data.Migrations
{
    public partial class ChangesforUserChats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Chats_ChatId",
                table: "UserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Users_UserCellId",
                table: "UserChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat");

            migrationBuilder.RenameTable(
                name: "UserChat",
                newName: "UserChats");

            migrationBuilder.RenameIndex(
                name: "IX_UserChat_ChatId",
                table: "UserChats",
                newName: "IX_UserChats_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChats",
                table: "UserChats",
                columns: new[] { "UserCellId", "ChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Users_UserCellId",
                table: "UserChats",
                column: "UserCellId",
                principalTable: "Users",
                principalColumn: "UserCellId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Users_UserCellId",
                table: "UserChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChats",
                table: "UserChats");

            migrationBuilder.RenameTable(
                name: "UserChats",
                newName: "UserChat");

            migrationBuilder.RenameIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChat",
                newName: "IX_UserChat_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat",
                columns: new[] { "UserCellId", "ChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Chats_ChatId",
                table: "UserChat",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Users_UserCellId",
                table: "UserChat",
                column: "UserCellId",
                principalTable: "Users",
                principalColumn: "UserCellId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
