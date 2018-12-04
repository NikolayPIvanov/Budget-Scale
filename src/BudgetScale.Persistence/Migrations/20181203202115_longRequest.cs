using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetScale.Persistence.Migrations
{
    public partial class longRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LongRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RequestDescription = table.Column<string>(nullable: true),
                    ElapsedMilliseconds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LongRequests");
        }
    }
}
