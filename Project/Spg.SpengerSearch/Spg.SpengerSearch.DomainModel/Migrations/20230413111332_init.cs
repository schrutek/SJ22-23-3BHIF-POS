using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spg.SpengerSearch.DomainModel.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    EMail = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address_StreetName = table.Column<string>(type: "TEXT", nullable: false),
                    Address_BuildingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Zip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanySuffix = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    CatchPhrase = table.Column<string>(type: "TEXT", nullable: false),
                    Bs = table.Column<string>(type: "TEXT", nullable: false),
                    Address_StreetName = table.Column<string>(type: "TEXT", nullable: false),
                    Address_BuildingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Zip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShopNavigationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryTypeKey = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryType_CategoryTypeKey",
                        column: x => x.CategoryTypeKey,
                        principalTable: "CategoryType",
                        principalColumn: "Key");
                    table.ForeignKey(
                        name: "FK_Categories_Shops_ShopNavigationId",
                        column: x => x.ShopNavigationId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Ean13 = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryNavigationId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.Description, x.Ean13 });
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryNavigationId1",
                        column: x => x.CategoryNavigationId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryTypeKey",
                table: "Categories",
                column: "CategoryTypeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShopNavigationId",
                table: "Categories",
                column: "ShopNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryNavigationId1",
                table: "Products",
                column: "CategoryNavigationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Description_Ean13",
                table: "Products",
                columns: new[] { "Name", "Ean13" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
