using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class updatingseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthorTypes",
                columns: new[] { "Id", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2640), "Студент", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2644), "Викладач", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ConferenceTypes",
                columns: new[] { "Id", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2656), "Всеукраїнська", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2659), "Регіональна", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2660), "Міжнародна", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 44, 52, 363, DateTimeKind.Local).AddTicks(2620));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 13, 43, 61, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 5, 18, 13, 43, 61, DateTimeKind.Local).AddTicks(7743));
        }
    }
}
