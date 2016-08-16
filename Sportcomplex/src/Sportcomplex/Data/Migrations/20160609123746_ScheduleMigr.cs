using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sportcomplex.Data.Migrations
{
    public partial class ScheduleMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheduleElements_Shedule_ScheduleId",
                table: "SheduleElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Space_Shedule_timetableId",
                table: "Space");

            migrationBuilder.DropIndex(
                name: "IX_SheduleElements_ScheduleId",
                table: "SheduleElements");

            migrationBuilder.DropColumn(
                name: "space_image",
                table: "Space");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "SheduleElements");

            migrationBuilder.AddColumn<string>(
                name: "SpaceDescription",
                table: "Space",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SheduleId",
                table: "SheduleElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheduleElements_SheduleId",
                table: "SheduleElements",
                column: "SheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SheduleElements_Shedule_SheduleId",
                table: "SheduleElements",
                column: "SheduleId",
                principalTable: "Shedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Space_Shedule_TimetableId",
                table: "Space",
                column: "TimetableId",
                principalTable: "Shedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "timetableId",
                table: "Space",
                newName: "TimetableId");

            migrationBuilder.RenameIndex(
                name: "IX_Space_timetableId",
                table: "Space",
                newName: "IX_Space_TimetableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheduleElements_Shedule_SheduleId",
                table: "SheduleElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Space_Shedule_TimetableId",
                table: "Space");

            migrationBuilder.DropIndex(
                name: "IX_SheduleElements_SheduleId",
                table: "SheduleElements");

            migrationBuilder.DropColumn(
                name: "SpaceDescription",
                table: "Space");

            migrationBuilder.DropColumn(
                name: "SheduleId",
                table: "SheduleElements");

            migrationBuilder.AddColumn<string>(
                name: "space_image",
                table: "Space",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScheduleId",
                table: "SheduleElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheduleElements_ScheduleId",
                table: "SheduleElements",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SheduleElements_Shedule_ScheduleId",
                table: "SheduleElements",
                column: "ScheduleId",
                principalTable: "Shedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Space_Shedule_timetableId",
                table: "Space",
                column: "timetableId",
                principalTable: "Shedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "TimetableId",
                table: "Space",
                newName: "timetableId");

            migrationBuilder.RenameIndex(
                name: "IX_Space_TimetableId",
                table: "Space",
                newName: "IX_Space_timetableId");
        }
    }
}
