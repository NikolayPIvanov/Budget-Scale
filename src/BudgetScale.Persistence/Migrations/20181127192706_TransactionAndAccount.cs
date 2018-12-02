using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetScale.Persistence.Migrations
{
    public partial class TransactionAndAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryInformation_Categories_CategoryId",
                table: "CategoryInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryInformation",
                table: "CategoryInformation");

            migrationBuilder.RenameTable(
                name: "CategoryInformation",
                newName: "CategoryInformations");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryInformation_CategoryId",
                table: "CategoryInformations",
                newName: "IX_CategoryInformations_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryInformations",
                table: "CategoryInformations",
                column: "CategoryInformationId");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: true),
                    AccountId = table.Column<string>(nullable: false),
                    AccountName = table.Column<string>(maxLength: 20, nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(nullable: false),
                    SourceAccountId = table.Column<string>(nullable: true),
                    DestinationAccountId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryInformations_Categories_CategoryId",
                table: "CategoryInformations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryInformations_Categories_CategoryId",
                table: "CategoryInformations");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryInformations",
                table: "CategoryInformations");

            migrationBuilder.RenameTable(
                name: "CategoryInformations",
                newName: "CategoryInformation");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryInformations_CategoryId",
                table: "CategoryInformation",
                newName: "IX_CategoryInformation_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryInformation",
                table: "CategoryInformation",
                column: "CategoryInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryInformation_Categories_CategoryId",
                table: "CategoryInformation",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
