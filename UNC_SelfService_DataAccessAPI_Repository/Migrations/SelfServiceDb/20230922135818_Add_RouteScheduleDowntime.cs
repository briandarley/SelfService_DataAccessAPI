using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNC_SelfService_DataAccessAPI_Repository.Migrations.SelfServiceDb
{
    /// <inheritdoc />
    public partial class Add_RouteScheduleDowntime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouteScheduleDowntime",
                schema: "SelfService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteItemId = table.Column<int>(type: "int", nullable: false),
                    ScheduledOnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ScheduledOffDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NewRoute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CurrentRoute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteScheduleDowntime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteScheduleDowntime_RouteItem_RouteItemId",
                        column: x => x.RouteItemId,
                        principalSchema: "SelfService",
                        principalTable: "RouteItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteScheduleDowntime_RouteItemId",
                schema: "SelfService",
                table: "RouteScheduleDowntime",
                column: "RouteItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteScheduleDowntime",
                schema: "SelfService");
        }
    }
}
