using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sportcomplex.Data.Migrations
{
    public partial class RequiredMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "TimeOfGym",
                table: "Price",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfSport",
                table: "Price",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "MainImageURL",
                table: "Main",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Contact",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comments",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TimeOfGym",
                table: "Price",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfSport",
                table: "Price",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainImageURL",
                table: "Main",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Contact",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comments",
                nullable: true);
        }
    }
}
