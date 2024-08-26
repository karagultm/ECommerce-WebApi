using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 6, DateTimeKind.Local).AddTicks(7550), "Movies, Home & Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 6, DateTimeKind.Local).AddTicks(7567), "Beauty, Kids & Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 6, DateTimeKind.Local).AddTicks(7579), "Electronics & Games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 13, 49, 6, 7, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 13, 49, 6, 7, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 13, 49, 6, 7, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 13, 49, 6, 7, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 9, DateTimeKind.Local).AddTicks(1305), "Anlamsız vitae de iure sinema.", "Voluptatem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 9, DateTimeKind.Local).AddTicks(1404), "Çobanın labore biber için umut.", "Nemo." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 9, DateTimeKind.Local).AddTicks(1439), "Et makinesi totam layıkıyla veniam.", "Dergi." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 12, DateTimeKind.Local).AddTicks(7916), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 8.183757427360170m, 95.00m, "Practical Wooden Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 13, 49, 6, 12, DateTimeKind.Local).AddTicks(7944), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 9.092312036088530m, 280.11m, "Awesome Metal Cheese" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(4408), "Games & Clothing" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(4417), "Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(4441), "Clothing, Grocery & Electronics" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 14, 45, 5, 615, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 617, DateTimeKind.Local).AddTicks(7132), "Telefonu beğendim layıkıyla consequuntur in.", "Sit." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 617, DateTimeKind.Local).AddTicks(7174), "Iure cezbelendi nihil quasi enim.", "Vel." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 617, DateTimeKind.Local).AddTicks(7211), "Dolores ipsa açılmadan türemiş aspernatur.", "Ea." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 619, DateTimeKind.Local).AddTicks(9928), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 5.091838105440670m, 455.80m, "Ergonomic Soft Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 45, 5, 619, DateTimeKind.Local).AddTicks(9976), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 0.6382621255506340m, 894.98m, "Sleek Fresh Towels" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
