using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class renamingconferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferentions_ConferentionTypes_ConferenceTypeId",
                table: "Conferentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Conferentions_ConferenceId",
                table: "Publications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferentionTypes",
                table: "ConferentionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conferentions",
                table: "Conferentions");

            migrationBuilder.RenameTable(
                name: "ConferentionTypes",
                newName: "ConferenceTypes");

            migrationBuilder.RenameTable(
                name: "Conferentions",
                newName: "Conferences");

            migrationBuilder.RenameIndex(
                name: "IX_Conferentions_ConferenceTypeId",
                table: "Conferences",
                newName: "IX_Conferences_ConferenceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceTypes",
                table: "ConferenceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_ConferenceTypes_ConferenceTypeId",
                table: "Conferences",
                column: "ConferenceTypeId",
                principalTable: "ConferenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Conferences_ConferenceId",
                table: "Publications",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_ConferenceTypes_ConferenceTypeId",
                table: "Conferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Conferences_ConferenceId",
                table: "Publications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceTypes",
                table: "ConferenceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences");

            migrationBuilder.RenameTable(
                name: "ConferenceTypes",
                newName: "ConferentionTypes");

            migrationBuilder.RenameTable(
                name: "Conferences",
                newName: "Conferentions");

            migrationBuilder.RenameIndex(
                name: "IX_Conferences_ConferenceTypeId",
                table: "Conferentions",
                newName: "IX_Conferentions_ConferenceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferentionTypes",
                table: "ConferentionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conferentions",
                table: "Conferentions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferentions_ConferentionTypes_ConferenceTypeId",
                table: "Conferentions",
                column: "ConferenceTypeId",
                principalTable: "ConferentionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Conferentions_ConferenceId",
                table: "Publications",
                column: "ConferenceId",
                principalTable: "Conferentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
