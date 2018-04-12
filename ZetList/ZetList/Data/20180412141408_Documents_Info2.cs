using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZetMigrations.Migrations
{
    public partial class Documents_Info2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info2",
                table: "Documents",
                nullable: true);

            migrationBuilder.Sql(
            @"
                UPDATE Documents
                SET Info2 = Info;
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info2",
                table: "Documents");
        }
    }
}
