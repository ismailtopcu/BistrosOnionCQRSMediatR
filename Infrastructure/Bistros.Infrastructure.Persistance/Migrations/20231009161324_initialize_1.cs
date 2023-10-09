using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bistros.Infrastructure.Persistance.Migrations
{
    public partial class initialize_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FoodPrice",
                table: "Foods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodPrice",
                table: "Foods");
        }
    }
}
