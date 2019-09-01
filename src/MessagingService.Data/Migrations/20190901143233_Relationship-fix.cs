using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Data.Migrations
{
    public partial class Relationshipfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_MessageSender_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MessageSenderMessageId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MessageSenderSenderCellId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSender_MessageId",
                table: "MessageSender",
                column: "MessageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MessageSender_MessageId",
                table: "MessageSender");

            migrationBuilder.AddColumn<Guid>(
                name: "MessageSenderMessageId",
                table: "Chats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageSenderSenderCellId",
                table: "Chats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats",
                columns: new[] { "MessageSenderMessageId", "MessageSenderSenderCellId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_MessageSender_MessageSenderMessageId_MessageSenderSenderCellId",
                table: "Chats",
                columns: new[] { "MessageSenderMessageId", "MessageSenderSenderCellId" },
                principalTable: "MessageSender",
                principalColumns: new[] { "MessageId", "SenderCellId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
