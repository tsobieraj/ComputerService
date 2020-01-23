using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerService.Migrations
{
    public partial class AlterItemsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Price" },
                values: new object[] { 2, 15m });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[] { 2, 0, "Test 2", 20m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Price" },
                values: new object[] { 1, 10m });
        }
    }
}
