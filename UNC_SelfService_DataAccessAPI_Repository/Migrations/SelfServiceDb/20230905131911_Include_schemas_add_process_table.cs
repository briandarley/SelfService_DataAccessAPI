using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNC_SelfService_DataAccessAPI_Repository.Migrations.SelfServiceDb
{
    /// <inheritdoc />
    public partial class Include_schemas_add_process_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UtilityDb");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnitAdmin",
                newName: "OrganizationalUnitAdmin",
                newSchema: "UtilityDb");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnit",
                newName: "OrganizationalUnit",
                newSchema: "UtilityDb");

            migrationBuilder.RenameTable(
                name: "AppSetting",
                newName: "AppSetting",
                newSchema: "UtilityDb");

            migrationBuilder.RenameTable(
                name: "ApiEndpoint",
                newName: "ApiEndpoint",
                newSchema: "UtilityDb");

            migrationBuilder.CreateTable(
                name: "Process",
                schema: "UtilityDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProcessType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Arguments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    AppDomain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QueueName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpiryTimeSeconds = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessHistory",
                schema: "UtilityDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Failed = table.Column<bool>(type: "bit", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arguments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessSchedule",
                schema: "UtilityDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    EnabledDays = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepeatCycle = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    RepeatInterval = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessSchedule_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalSchema: "UtilityDb",
                        principalTable: "Process",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessSchedule_ProcessId",
                schema: "UtilityDb",
                table: "ProcessSchedule",
                column: "ProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessHistory",
                schema: "UtilityDb");

            migrationBuilder.DropTable(
                name: "ProcessSchedule",
                schema: "UtilityDb");

            migrationBuilder.DropTable(
                name: "Process",
                schema: "UtilityDb");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnitAdmin",
                schema: "UtilityDb",
                newName: "OrganizationalUnitAdmin");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnit",
                schema: "UtilityDb",
                newName: "OrganizationalUnit");

            migrationBuilder.RenameTable(
                name: "AppSetting",
                schema: "UtilityDb",
                newName: "AppSetting");

            migrationBuilder.RenameTable(
                name: "ApiEndpoint",
                schema: "UtilityDb",
                newName: "ApiEndpoint");
        }
    }
}
