using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZetMigrations.Migrations
{
    public partial class Documents_NameAndFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAndFilePath",
                table: "Documents",
                nullable: true);

            migrationBuilder.Sql(
            @"
                UPDATE Documents
                SET NameAndFilePath = Name || ' ' || FilePath;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "NameAndFilePath",
                table: "Documents");


        }
    }
}
