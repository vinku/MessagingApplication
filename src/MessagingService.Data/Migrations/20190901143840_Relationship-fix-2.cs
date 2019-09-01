using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Data.Migrations
{
    public partial class Relationshipfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageSender_Users_SenderUserId",
                table: "MessageSender");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Users_UserId",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_UserChat_UserId",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_MessageSender_SenderUserId",
                table: "MessageSender");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserChat");

            migrationBuilder.DropColumn(
                name: "SenderUserId",
                table: "MessageSender");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserCellId");

            migrationBuilder.RenameColumn(
                name: "SenderCellId",
                table: "MessageSender",
                newName: "UserCellId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSender_UserCellId",
                table: "MessageSender",
                column: "UserCellId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSender_Users_UserCellId",
                table: "MessageSender",
                column: "UserCellId",
                principalTable: "Users",
                principalColumn: "UserCellId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Users_UserCellId",
                table: "UserChat",
                column: "UserCellId",
                principalTable: "Users",
                principalColumn: "UserCellId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageSender_Users_UserCellId",
                table: "MessageSender");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Users_UserCellId",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_MessageSender_UserCellId",
                table: "MessageSender");

            migrationBuilder.RenameColumn(
                name: "UserCellId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserCellId",
                table: "MessageSender",
                newName: "SenderCellId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserChat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderUserId",
                table: "MessageSender",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_UserId",
                table: "UserChat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSender_SenderUserId",
                table: "MessageSender",
                column: "SenderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSender_Users_SenderUserId",
                table: "MessageSender",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Users_UserId",
                table: "UserChat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
