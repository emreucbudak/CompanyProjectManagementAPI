using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskProjectManagementApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IdentitysAddied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d08e95e-3e09-457e-acd2-77fe5e9df592"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("436d4f15-f5f7-42c5-beed-e613110c4fd6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88aa7745-12ce-4e61-a6ec-42dcfb212982"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", "Worker", "WORKER" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "CompanyAuthor", "COMPANYAUTHOR" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "cccccccc-cccc-cccc-cccc-cccccccccccc", "ReporterWorker", "REPORTERWORKER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3d08e95e-3e09-457e-acd2-77fe5e9df592"), "f5ebfe19-fe78-4eaa-be85-6a10984b6dd5", "Worker", "WORKER" },
                    { new Guid("436d4f15-f5f7-42c5-beed-e613110c4fd6"), "7e145deb-a47f-46e1-bf31-096b24133bf3", "CompanyAuthor", "COMPANYAUTHOR" },
                    { new Guid("88aa7745-12ce-4e61-a6ec-42dcfb212982"), "28a3694c-82a0-4108-acb5-6aa67137be9f", "ReporterWorker", "REPORTERWORKER" }
                });
        }
    }
}
