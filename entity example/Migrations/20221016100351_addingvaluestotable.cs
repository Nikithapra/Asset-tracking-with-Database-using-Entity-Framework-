using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_example.Migrations
{
    public partial class addingvaluestotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assetnew1",
                columns: new[] { "Id", "PBrand", "PCurrency", "PModel", "POffices", "PPrice", "PPurcdate", "Ptype", "locPrice" },
                values: new object[,]
                {
                    { 2, "Samsung", "EUR", "S10", "Spain", 6000.0, new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile", 6179f },
                    { 3, "Iphone", "EUR", "I20", "Spain", 4000.0, new DateTime(2019, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile", 4030f },
                    { 4, "Azure", "SEK", "AX2", "Sweden", 7000.0, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer", 79468f },
                    { 5, "Lava", "SEK", "LX2", "Sweden", 7000.0, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile", 79468f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assetnew1",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assetnew1",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assetnew1",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assetnew1",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
