using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Data.Migrations
{
    public partial class Messages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Chats_ChatId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Messages_MessageId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageSender_Messages_MessageId",
                table: "MessageSender");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageSender_Users_UserCellId",
                table: "MessageSender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageSender",
                table: "MessageSender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage");

            migrationBuilder.RenameTable(
                name: "MessageSender",
                newName: "MessageSenders");

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_MessageSender_UserCellId",
                table: "MessageSenders",
                newName: "IX_MessageSenders_UserCellId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageSender_MessageId",
                table: "MessageSenders",
                newName: "IX_MessageSenders_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_MessageId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageSenders",
                table: "MessageSenders",
                columns: new[] { "MessageId", "UserCellId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                columns: new[] { "ChatId", "MessageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Chats_ChatId",
                table: "ChatMessages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Messages_MessageId",
                table: "ChatMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSenders_Messages_MessageId",
                table: "MessageSenders",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSenders_Users_UserCellId",
                table: "MessageSenders",
                column: "UserCellId",
                principalTable: "Users",
                principalColumn: "UserCellId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Chats_ChatId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Messages_MessageId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageSenders_Messages_MessageId",
                table: "MessageSenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageSenders_Users_UserCellId",
                table: "MessageSenders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageSenders",
                table: "MessageSenders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "MessageSenders",
                newName: "MessageSender");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessage");

            migrationBuilder.RenameIndex(
                name: "IX_MessageSenders_UserCellId",
                table: "MessageSender",
                newName: "IX_MessageSender_UserCellId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageSenders_MessageId",
                table: "MessageSender",
                newName: "IX_MessageSender_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_MessageId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageSender",
                table: "MessageSender",
                columns: new[] { "MessageId", "UserCellId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage",
                columns: new[] { "ChatId", "MessageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Chats_ChatId",
                table: "ChatMessage",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Messages_MessageId",
                table: "ChatMessage",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSender_Messages_MessageId",
                table: "MessageSender",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSender_Users_UserCellId",
                table: "MessageSender",
                column: "UserCellId",
                principalTable: "Users",
                principalColumn: "UserCellId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
