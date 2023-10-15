using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorMixes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCombinationTableAndRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstColorId = table.Column<int>(type: "int", nullable: true),
                    SecondColorId = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combinations_Colors_FirstColorId",
                        column: x => x.FirstColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Combinations_Colors_SecondColorId",
                        column: x => x.SecondColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_FirstColorId",
                table: "Combinations",
                column: "FirstColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_SecondColorId",
                table: "Combinations",
                column: "SecondColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combinations");
        }
    }
}
