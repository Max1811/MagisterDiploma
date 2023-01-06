using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3157), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3162), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3180), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3178) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3184), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3183) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3187), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3185) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3130), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3136), new DateTime(2023, 1, 6, 20, 18, 12, 541, DateTimeKind.Local).AddTicks(3135) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(348), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "AuthorTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(352), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(351) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(370), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(369) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(375), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(373) });

            migrationBuilder.UpdateData(
                table: "ConferenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(378), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(376) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(313), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "PublicationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(320), new DateTime(2023, 1, 6, 20, 15, 48, 795, DateTimeKind.Local).AddTicks(319) });
        }
    }
}
