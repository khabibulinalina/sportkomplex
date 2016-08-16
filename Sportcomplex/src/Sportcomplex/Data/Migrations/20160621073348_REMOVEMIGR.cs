using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sportcomplex.Data.Migrations
{
    public partial class REMOVEMIGR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_service",
                table: "service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "service",
                newName: "Service");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service",
                table: "service",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "service");
        }
    }
}
