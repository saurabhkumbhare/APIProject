using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ShopBridge.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    item_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    item_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sales_price = table.Column<float>(type: "real", nullable: false),
                    unit_of_measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hsn_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.item_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
