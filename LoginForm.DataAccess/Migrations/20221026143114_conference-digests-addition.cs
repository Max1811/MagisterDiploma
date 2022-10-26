using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginForm.DataAccess.Migrations
{
    public partial class conferencedigestsaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferentionName",
                table: "Publications",
                newName: "Organization");

            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DigestId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConferentionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferentionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Digests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Digests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conferentions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceTypeId = table.Column<int>(type: "int", nullable: false),
                    ConferenceCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conferentions_ConferentionTypes_ConferenceTypeId",
                        column: x => x.ConferenceTypeId,
                        principalTable: "ConferentionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ConferenceId",
                table: "Publications",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_DigestId",
                table: "Publications",
                column: "DigestId");

            migrationBuilder.CreateIndex(
                name: "IX_Conferentions_ConferenceTypeId",
                table: "Conferentions",
                column: "ConferenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Conferentions_ConferenceId",
                table: "Publications",
                column: "ConferenceId",
                principalTable: "Conferentions",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Conferentions_ConferenceId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Digests_DigestId",
                table: "Publications");

            migrationBuilder.DropTable(
                name: "Conferentions");

            migrationBuilder.DropTable(
                name: "Digests");

            migrationBuilder.DropTable(
                name: "ConferentionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Publications_ConferenceId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_DigestId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "DigestId",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "Organization",
                table: "Publications",
                newName: "ConferentionName");
        }
    }
}
