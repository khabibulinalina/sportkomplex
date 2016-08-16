using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sportcomplex.Data.Migrations
{
    public partial class REMOVEMIGRATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SheduleElements");

            migrationBuilder.DropTable(
                name: "Space");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Shedule");

            migrationBuilder.DropTable(
                name: "TimeScheme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    SpaceDescription = table.Column<string>(nullable: true),
                    TimetableId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Space", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Space_Shedule_TimetableId",
                        column: x => x.TimetableId,
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
                    SheduleId = table.Column<long>(nullable: true),
                    TimeId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    weekday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheduleElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheduleElements_Shedule_SheduleId",
                        column: x => x.SheduleId,
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
                name: "IX_SheduleElements_SheduleId",
                table: "SheduleElements",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SheduleElements_TimeId",
                table: "SheduleElements",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_TimeSchemeId",
                table: "Time",
                column: "TimeSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Space_TimetableId",
                table: "Space",
                column: "TimetableId");
        }
    }
}
