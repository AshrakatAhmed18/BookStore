using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksEccommerce.Migrations
{
    /// <inheritdoc />
    public partial class bookimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Books");
        }
    }
}
