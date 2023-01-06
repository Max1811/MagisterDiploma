using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class updatepublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "PublicationTypes",
                columns: new[] { "Id", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 1, 5, 18, 13, 43, 61, DateTimeKind.Local).AddTicks(7711), "Конференція", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PublicationTypes",
                columns: new[] { "Id", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2023, 1, 5, 18, 13, 43, 61, DateTimeKind.Local).AddTicks(7743), "Стаття", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Publications");
        }
    }
}
