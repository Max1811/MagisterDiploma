using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class seedchangepublicationtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5385), "Теза" });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5419));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2593), "Конференція" });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2620));
        }
    }
}
