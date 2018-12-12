using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetScale.Persistence.Migrations
{
    public partial class removedCategoryInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Activity",
                table: "Categories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Available",
                table: "Categories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Budgeted",
                table: "Categories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Budgeted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Categories");
        }
    }
}
