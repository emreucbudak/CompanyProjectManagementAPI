using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskProjectManagementApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EntityDesigned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "workers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "workers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "workers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "systemOwners");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "systemOwners");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "systemOwners");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "reporterWorkers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "reporterWorkers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "reporterWorkers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "companiesAuthor");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "companiesAuthor");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "companiesAuthor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "systemOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "systemOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "systemOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "reporterWorkers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "reporterWorkers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "reporterWorkers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "companiesAuthor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "companiesAuthor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "companiesAuthor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
