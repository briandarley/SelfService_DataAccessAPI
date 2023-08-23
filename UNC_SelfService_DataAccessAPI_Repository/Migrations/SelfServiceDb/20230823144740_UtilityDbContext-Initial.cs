using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNC_SelfService_DataAccessAPI_Repository.Migrations.SelfServiceDb
{
    /// <inheritdoc />
    public partial class UtilityDbContextInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverLoad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppDomain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");
        }
    }
}
