using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class changingtonullabletypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(8996), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9001), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9017), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9016) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9021), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9020) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9024), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(9023) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(8968), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(8974), new DateTime(2023, 1, 6, 20, 11, 54, 9, DateTimeKind.Local).AddTicks(8973) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5438), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5442), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5458), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5461), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5463), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5385), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 5, 1, 272, DateTimeKind.Local).AddTicks(5419), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
