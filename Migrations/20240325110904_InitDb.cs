using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TF_Net2024_DemoEntity.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "John"),
                    LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PSEUDO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERSON_PSEUDO",
                table: "PERSON",
                column: "PSEUDO",
                unique: true,
                filter: "[PSEUDO] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERSON");
        }
    }
}
