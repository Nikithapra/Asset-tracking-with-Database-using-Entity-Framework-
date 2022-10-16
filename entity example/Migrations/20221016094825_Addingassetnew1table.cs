using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_example.Migrations
{
    public partial class Addingassetnew1table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assetnew1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ptype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POffices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPurcdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PPrice = table.Column<double>(type: "float", nullable: false),
                    PCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assetnew1", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assetnew1");
        }
    }
}
