using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Data.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CellNumber",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Chats",
                newName: "ChatId");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivityTime",
                table: "Chats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "MessageSenderMessageId",
                table: "Chats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageSenderSenderCellId",
                table: "Chats",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    ChatId = table.Column<Guid>(nullable: false),
                    MessageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => new { x.ChatId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_ChatMessage_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessage_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageSender",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(nullable: false),
                    SenderCellId = table.Column<string>(nullable: false),
                    SenderUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageSender", x => new { x.MessageId, x.SenderCellId });
                    table.ForeignKey(
                        name: "FK_MessageSender_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageSender_Users_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserChat",
                columns: table => new
                {
                    UserCellId = table.Column<string>(nullable: false),
                    ChatId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChat", x => new { x.UserCellId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_UserChat_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChat_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats",
                columns: new[] { "MessageSenderMessageId", "MessageSenderSenderCellId" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_MessageId",
                table: "ChatMessage",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageSender_SenderUserId",
                table: "MessageSender",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_ChatId",
                table: "UserChat",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_UserId",
                table: "UserChat",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_MessageSender_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats",
                columns: new[] { "MessageSenderMessageId", "MessageSenderSenderCellId" },
                principalTable: "MessageSender",
                principalColumns: new[] { "MessageId", "SenderCellId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_MessageSender_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "MessageSender");

            migrationBuilder.DropTable(
                name: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_Chats_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "LastActivityTime",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MessageSenderMessageId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MessageSenderSenderCellId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "CellNumber");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Chats",
                newName: "Id");
        }
    }
}
