using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNC_SelfService_DataAccessAPI_Repository.Migrations.SelfServiceDb
{
    /// <inheritdoc />
    public partial class Add_OuAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationalUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DistinguishedName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OuAdminGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdsPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ObjectGuid = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsRootOu = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalUnitAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationalUnitId = table.Column<int>(type: "int", nullable: false),
                    SamAccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalUnitAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationalUnitAdmin_OrganizationalUnit_OrganizationalUnitId",
                        column: x => x.OrganizationalUnitId,
                        principalTable: "OrganizationalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnitAdmin_OrganizationalUnitId",
                table: "OrganizationalUnitAdmin",
                column: "OrganizationalUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationalUnitAdmin");

            migrationBuilder.DropTable(
                name: "OrganizationalUnit");
        }
    }
}
