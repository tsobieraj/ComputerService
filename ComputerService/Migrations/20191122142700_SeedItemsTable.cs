using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerService.Migrations
{
    public partial class SeedItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[] { 1, 1, "Test 1", 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
