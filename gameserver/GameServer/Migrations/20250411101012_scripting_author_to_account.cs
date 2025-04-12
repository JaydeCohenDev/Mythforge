using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class scripting_author_to_account : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorAccountId",
                table: "Scripts",
                newName: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_AuthorId",
                table: "Scripts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Accounts_AuthorId",
                table: "Scripts",
                column: "AuthorId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Accounts_AuthorId",
                table: "Scripts");

            migrationBuilder.DropIndex(
                name: "IX_Scripts_AuthorId",
                table: "Scripts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Scripts",
                newName: "AuthorAccountId");
        }
    }
}
