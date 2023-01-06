using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class updatenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Conferences_ConferenceId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Digests_DigestId",
                table: "Publications");

            migrationBuilder.AlterColumn<int>(
                name: "DigestId",
                table: "Publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Conferences_ConferenceId",
                table: "Publications",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Digests_DigestId",
                table: "Publications",
                column: "DigestId",
                principalTable: "Digests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Conferences_ConferenceId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Digests_DigestId",
                table: "Publications");

            migrationBuilder.AlterColumn<int>(
                name: "DigestId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Conferences_ConferenceId",
                table: "Publications",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Digests_DigestId",
                table: "Publications",
                column: "DigestId",
                principalTable: "Digests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
