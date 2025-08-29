using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskProjectManagementApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EntitySettinged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_systemOwners_UserId",
                table: "systemOwners");

            migrationBuilder.CreateIndex(
                name: "IX_systemOwners_UserId",
                table: "systemOwners",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_systemOwners_UserId",
                table: "systemOwners");

            migrationBuilder.CreateIndex(
                name: "IX_systemOwners_UserId",
                table: "systemOwners",
                column: "UserId");
        }
    }
}
