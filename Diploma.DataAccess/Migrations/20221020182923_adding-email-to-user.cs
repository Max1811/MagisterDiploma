﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    public partial class addingemailtouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");
        }
    }
}
