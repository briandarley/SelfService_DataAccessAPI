using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNC_SelfService_DataAccessAPI_Repository.Migrations.SelfServiceDb
{
    /// <inheritdoc />
    public partial class Add_MenuItem_RouteItem_Tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SelfService");

            migrationBuilder.CreateTable(
                name: "RouteItem",
                schema: "SelfService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SearchDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Searchable = table.Column<bool>(type: "bit", nullable: false),
                    LinkText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequireAuth = table.Column<bool>(type: "bit", nullable: false),
                    RequireMfa = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                schema: "SelfService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteItemId = table.Column<int>(type: "int", nullable: false),
                    MenuText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ParentMenuItemId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItem_ParentMenuItemId",
                        column: x => x.ParentMenuItemId,
                        principalSchema: "SelfService",
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItem_RouteItem_RouteItemId",
                        column: x => x.RouteItemId,
                        principalSchema: "SelfService",
                        principalTable: "RouteItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteItemTag",
                schema: "SelfService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteItemId = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteItemTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteItemTag_RouteItem_RouteItemId",
                        column: x => x.RouteItemId,
                        principalSchema: "SelfService",
                        principalTable: "RouteItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ParentMenuItemId",
                schema: "SelfService",
                table: "MenuItem",
                column: "ParentMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RouteItemId",
                schema: "SelfService",
                table: "MenuItem",
                column: "RouteItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteItemTag_RouteItemId",
                schema: "SelfService",
                table: "RouteItemTag",
                column: "RouteItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem",
                schema: "SelfService");

            migrationBuilder.DropTable(
                name: "RouteItemTag",
                schema: "SelfService");

            migrationBuilder.DropTable(
                name: "RouteItem",
                schema: "SelfService");
        }
    }
}
