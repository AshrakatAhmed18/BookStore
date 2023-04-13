using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksEccommerce.Migrations
{
    /// <inheritdoc />
    public partial class addQyantityToBookUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "qyantity",
                table: "booksUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qyantity",
                table: "booksUsers");
        }
    }
}
