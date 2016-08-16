using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sportcomplex.Data.Migrations
{
    public partial class ModelMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    x = table.Column<decimal>(nullable: false, type: "decimal(5,6)"),
                    y = table.Column<decimal>(nullable: false, type: "decimal(5,6)"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Eight_work = table.Column<string>(nullable: true),
                    Eleven_work = table.Column<string>(nullable: true),
                    For_work = table.Column<string>(nullable: true),
                    NameOfSport = table.Column<string>(nullable: true),
                    One_work = table.Column<string>(nullable: true),
                    TimeOfGym = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeScheme",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ServiceImgURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shedule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeSchemeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shedule_TimeScheme_TimeSchemeId",
                        column: x => x.TimeSchemeId,
                        principalTable: "TimeScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    TimeSchemeId = table.Column<long>(nullable: true),
                    Time_end = table.Column<string>(nullable: true),
                    Time_start = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Time_TimeScheme_TimeSchemeId",
                        column: x => x.TimeSchemeId,
                        principalTable: "TimeScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Space",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    space_image = table.Column<string>(nullable: true),
                    timetableId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Space", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Space_Shedule_timetableId",
                        column: x => x.timetableId,
                        principalTable: "Shedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SheduleElements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleId = table.Column<long>(nullable: true),
                    TimeId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    weekday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheduleElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheduleElements_Shedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Shedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheduleElements_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shedule_TimeSchemeId",
                table: "Shedule",
                column: "TimeSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheduleElements_ScheduleId",
                table: "SheduleElements",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SheduleElements_TimeId",
                table: "SheduleElements",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_TimeSchemeId",
                table: "Time",
                column: "TimeSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Space_timetableId",
                table: "Space",
                column: "timetableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "SheduleElements");

            migrationBuilder.DropTable(
                name: "Space");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Shedule");

            migrationBuilder.DropTable(
                name: "TimeScheme");
        }
    }
}
