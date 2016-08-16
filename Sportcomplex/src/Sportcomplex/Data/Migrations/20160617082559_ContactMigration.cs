using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sportcomplex.Data.Migrations
{
    public partial class ContactMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service",
                table: "service",
                column: "Id");

            migrationBuilder.AlterColumn<double>(
                name: "y",
                table: "Contact",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "x",
                table: "Contact",
                nullable: false);

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "service");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_service",
                table: "service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "y",
                table: "Contact",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "x",
                table: "Contact",
                nullable: false);

            migrationBuilder.RenameTable(
                name: "service",
                newName: "Service");
        }
    }
}
