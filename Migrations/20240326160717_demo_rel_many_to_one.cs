using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TF_Net2024_DemoEntity.Migrations
{
    /// <inheritdoc />
    public partial class demo_rel_many_to_one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "PERSON",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HomeAddresses",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeAddresses", x => x.HomeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERSON_HomeId",
                table: "PERSON",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PERSON_HomeAddresses_HomeId",
                table: "PERSON",
                column: "HomeId",
                principalTable: "HomeAddresses",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSON_HomeAddresses_HomeId",
                table: "PERSON");

            migrationBuilder.DropTable(
                name: "HomeAddresses");

            migrationBuilder.DropIndex(
                name: "IX_PERSON_HomeId",
                table: "PERSON");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "PERSON");
        }
    }
}
