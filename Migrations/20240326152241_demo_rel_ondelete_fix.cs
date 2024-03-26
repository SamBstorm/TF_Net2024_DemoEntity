using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TF_Net2024_DemoEntity.Migrations
{
    /// <inheritdoc />
    public partial class demo_rel_ondelete_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_PERSON_TitularId",
                table: "BankAccounts");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_PERSON_TitularId",
                table: "BankAccounts",
                column: "TitularId",
                principalTable: "PERSON",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_PERSON_TitularId",
                table: "BankAccounts");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_PERSON_TitularId",
                table: "BankAccounts",
                column: "TitularId",
                principalTable: "PERSON",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
