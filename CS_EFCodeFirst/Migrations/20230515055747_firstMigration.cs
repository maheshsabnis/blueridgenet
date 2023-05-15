using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS_EFCodeFirst.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatrgoryUniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatrgoryUniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductUniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CatrgoryUniqueId = table.Column<int>(type: "int", nullable: false),
                    CategoryCatrgoryUniqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductUniqueId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryCatrgoryUniqueId",
                        column: x => x.CategoryCatrgoryUniqueId,
                        principalTable: "Categories",
                        principalColumn: "CatrgoryUniqueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatrgoryUniqueId",
                table: "Products",
                column: "CategoryCatrgoryUniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
