using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TF_Net2024_DemoEntity.Migrations
{
    /// <inheritdoc />
    public partial class demo_rel_one_to_one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "CHAR(16)", maxLength: 16, nullable: false),
                    Bank_name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Amount = table.Column<decimal>(type: "MONEY", nullable: false, defaultValue: 0m),
                    TitularId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_BankAccounts_PERSON_TitularId",
                        column: x => x.TitularId,
                        principalTable: "PERSON",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_TitularId",
                table: "BankAccounts",
                column: "TitularId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
