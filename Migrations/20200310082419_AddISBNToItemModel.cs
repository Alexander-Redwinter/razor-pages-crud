using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorCRUD.Migrations
{
    public partial class AddISBNToItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Item");
        }
    }
}
