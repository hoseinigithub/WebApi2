using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInRoles_Users_UserId1",
                table: "UserInRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserInRoles_UserId1",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserInRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_UserId",
                table: "UserInRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInRoles_Users_UserId",
                table: "UserInRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInRoles_Users_UserId",
                table: "UserInRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserInRoles_UserId",
                table: "UserInRoles");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "UserInRoles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_UserId1",
                table: "UserInRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInRoles_Users_UserId1",
                table: "UserInRoles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
