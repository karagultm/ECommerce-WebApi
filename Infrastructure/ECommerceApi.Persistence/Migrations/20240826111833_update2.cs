using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 244, DateTimeKind.Local).AddTicks(6084), "Baby & Garden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 244, DateTimeKind.Local).AddTicks(6103), "Home, Jewelery & Garden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 244, DateTimeKind.Local).AddTicks(6118), "Home, Grocery & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 14, 18, 33, 245, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 14, 18, 33, 245, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 14, 18, 33, 245, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 14, 18, 33, 245, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 248, DateTimeKind.Local).AddTicks(665), "Quia balıkhaneye şafak mıknatıslı sed.", "Lakin." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 248, DateTimeKind.Local).AddTicks(704), "Rem oldular exercitationem dolor bundan.", "Voluptate." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 248, DateTimeKind.Local).AddTicks(744), "Sayfası iusto bahar ex cezbelendi.", "Kalemi." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 251, DateTimeKind.Local).AddTicks(1165), "The Football Is Good For Training And Recreational Purposes", 9.192973414996250m, 335.52m, "Refined Rubber Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 26, 14, 18, 33, 251, DateTimeKind.Local).AddTicks(1193), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 7.673532691411220m, 642.50m, "Handcrafted Wooden Sausages" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
