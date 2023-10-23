using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartAdminMetronic.Migrations
{
    /// <inheritdoc />
    public partial class categoryThumbnail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThimbnailImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThimbnailImage",
                table: "Categories");
        }
    }
}
